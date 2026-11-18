using System;
using System.Collections.Generic;
using System.IO;

namespace MarathonSoundGen
{
    public class MacResourceFile : IDisposable
    {

        #region Public Properties

        public bool IsOpen
        {
            get
            {
                return mStream != null;
            }
        }

        public int Error { get; private set; }

        #endregion

        #region Private Properties

        private FileStream mStream;
        private readonly Dictionary<MacResourceKey, long> mEntries = new Dictionary<MacResourceKey, long>();

        #endregion

        #region Public Members

        public List<short> GetResourceIds(uint type)
        {
            List<short> result = new List<short>();

            if (mStream == null)
            {
                return result;
            }

            foreach (KeyValuePair<MacResourceKey, long> item in mEntries)
            {
                if (item.Key.Type == type)
                {
                    result.Add(item.Key.Id);
                }
            }

            result.Sort();

            return result;
        }

        public bool Check(uint type, short id)
        {
            bool ok = mStream != null && mEntries.ContainsKey(new MacResourceKey(type, id));
            Error = ok ? 0 : MacFileError.NotFound;
            return ok;
        }

        public bool Get(uint type, short id, MacResource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            resource.Unload();
            long pos;

            if (mStream == null || !mEntries.TryGetValue(new MacResourceKey(type, id), out pos))
            {
                Error = MacFileError.NotFound;
                return false;
            }

            try
            {
                mStream.Position = pos;

                using (BigEndianBinaryReader r = new BigEndianBinaryReader(mStream, true))
                {
                    uint size = r.ReadUInt32();

                    if (size > int.MaxValue || mStream.Position + size > mStream.Length)
                    {
                        return false;
                    }

                    resource.SetData(r.ReadBytesExactly((int)size));
                }

                Error = 0;
                return true;
            }
            catch
            {
                Error = MacFileError.Unknown;
                return false;
            }
        }
        public bool Close()
        {
            if (mStream != null)
            {
                mStream.Dispose();
            }

            mStream = null;
            mEntries.Clear();
            Error = 0;
            return true;
        }

        public void Dispose()
        {
            Close();
        }

        #endregion

        #region Private/Internal Members

        private bool Parse(FileStream fs)
        {
            mEntries.Clear();
            long fileSize = fs.Length, forkStart = 0, forkEnd = fileSize;

            if (fileSize < 16)
            {
                return false;
            }

            long o, l, dl, rl;

            if (MacContainerFormats.TryFindAppleSingleFork(fs, true, out o, out l))
            {
                forkStart = o;
                forkEnd = o + l;
            }
            else if (MacContainerFormats.TryReadMacBinary(fs, out dl, out rl))
            {
                forkStart = 128 + ((dl + 0x7f) & ~0x7f);
                forkEnd = forkStart + rl;
            }

            try
            {
                using (BigEndianBinaryReader r = new BigEndianBinaryReader(fs, true))
                {
                    fs.Position = forkStart;
                    long dataOffset = r.ReadUInt32() + forkStart;
                    long mapOffset = r.ReadUInt32() + forkStart;
                    long dataSize = r.ReadUInt32();
                    long mapSize = r.ReadUInt32();

                    if (dataOffset >= forkEnd || mapOffset >= forkEnd || dataOffset + dataSize > forkEnd || mapOffset + mapSize > forkEnd)
                    {
                        return false;
                    }

                    fs.Position = mapOffset + 24;
                    long typeListOffset = mapOffset + r.ReadUInt16();

                    if (typeListOffset >= forkEnd)
                    {
                        return false;
                    }

                    fs.Position = typeListOffset;
                    int typeCount = r.ReadUInt16() + 1;

                    for (int i = 0; i < typeCount; i++)
                    {
                        uint type = r.ReadUInt32();
                        int refs = r.ReadUInt16() + 1;
                        long refOffset = typeListOffset + r.ReadUInt16();

                        if (refOffset >= forkEnd)
                        {
                            return false;
                        }

                        long resume = fs.Position;
                        fs.Position = refOffset;

                        for (int j = 0; j < refs; j++)
                        {
                            short id = r.ReadInt16();
                            r.Skip(2);
                            long resourceDataOffset = dataOffset + (r.ReadUInt32() & 0x00ffffffu);

                            if (resourceDataOffset >= forkEnd)
                            {
                                return false;
                            }

                            mEntries[new MacResourceKey(type, id)] = resourceDataOffset;
                            r.Skip(4);
                        }

                        fs.Position = resume;
                    }
                }

                return true;
            }
            catch
            {
                mEntries.Clear();
                return false;
            }
        }

        internal bool Open(string basePath)
        {
            Close();

            string[] candidates =
            {
                basePath + ".rsrc",
                basePath + ".resources",
                basePath,
                basePath + "/..namedfork/rsrc"
            };

            foreach (string p in candidates)
            {
                try
                {
                    FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    if (Parse(fs))
                    {
                        mStream = fs;
                        Error = 0;
                        return true;
                    }

                    fs.Dispose();
                }
                catch
                {

                }
            }

            Error = MacFileError.Unknown;
            return false;
        }

        #endregion

    }
}
