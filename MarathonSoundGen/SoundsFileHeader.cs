using System;
using System.IO;

namespace MarathonSoundGen
{
    public class SoundsFileHeader : SoundInfo
    {

        #region Private Properties

        private const byte StdSH = 0x00, ExtSH = 0xff, CmpSH = 0xfe;
        private const ushort BufferCmd = 0x8051;
        private bool mSigned8Bits;
        private uint mDataOffset;

        #endregion

        #region Public Members

        public bool Load(BigEndianBinaryReader s)
        {
            Length = 0;
            mDataOffset = 0;
            long start = s.Position;

            try
            {
                s.Position = start + 20;
                byte encoding = s.ReadByte();
                s.Position = start;
                bool ok;

                switch (encoding)
                {
                    case StdSH:
                        ok = UnpackStandard(s);

                        if (ok)
                        {
                            mDataOffset = 22;
                        }

                        break;

                    case ExtSH:
                    case CmpSH:
                        ok = UnpackExtended(s);

                        if (ok)
                        {
                            mDataOffset = 64;
                        }

                        break;

                    default:
                        ok = false;
                        break;
                }

                return ok;
            }
            catch
            {
                return false;
            }
        }

        public byte[] LoadData(BigEndianBinaryReader r)
        {
            if (mDataOffset == 0 || Length <= 0)
            {
                return null;
            }

            try
            {
                r.Skip(mDataOffset);
                byte[] data = r.ReadBytesExactly(Length);

                if (BitsPerSample == 8 && mSigned8Bits)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = unchecked((byte)((sbyte)data[i] + 128));
                    }
                }
                else if (BitsPerSample == 16 && BitConverter.IsLittleEndian)
                {
                    for (int i = 0; i + 1 < data.Length; i += 2)
                    {
                        byte b = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = b;
                    }
                }

                return data;
            }
            catch
            {
                return null;
            }
        }

        public bool Load(MacFile f)
        {
            using (Stream s = f.BaseStream)
            using (BigEndianBinaryReader r = new BigEndianBinaryReader(s))
            {
                return Load(r);
            }
        }

        public byte[] LoadData(MacFile f)
        {
            using (Stream s = f.BaseStream)
            using (BigEndianBinaryReader r = new BigEndianBinaryReader(s))
            {
                return LoadData(r);
            }
        }

        public bool Load(MacResource resource)
        {
            if (resource == null || !resource.IsLoaded)
            {
                return false;
            }

            using (MemoryStream ms = new MemoryStream(resource.Data, false))
            using (BigEndianBinaryReader r = new BigEndianBinaryReader(ms))
            {
                try
                {
                    ushort format = r.ReadUInt16();

                    if (format != 1 && format != 2)
                    {
                        return false;
                    }

                    if (format == 1)
                    {
                        ushort n = r.ReadUInt16();
                        r.Skip(n * 6L);
                    }
                    else
                    {
                        r.Skip(2);
                    }

                    ushort cmds = r.ReadUInt16();

                    for (int i = 0; i < cmds; i++)
                    {
                        ushort cmd = r.ReadUInt16();
                        r.ReadUInt16();
                        uint param2 = r.ReadUInt32();

                        if (cmd == BufferCmd)
                        {
                            r.Position = param2;

                            if (Load(r))
                            {
                                mDataOffset += param2;
                                return true;
                            }
                        }
                    }

                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public byte[] LoadData(MacResource resource)
        {
            using (MemoryStream ms = new MemoryStream(resource.Data, false))
            using (BigEndianBinaryReader r = new BigEndianBinaryReader(ms))
            {
                return LoadData(r);
            }
        }

        #endregion

        #region Private Members

        private bool UnpackStandard(BigEndianBinaryReader r)
        {
            try
            {
                BytesPerFrame = 1;
                BitsPerSample = 8;
                Stereo = false;
                LittleEndian = false;
                r.Skip(4);
                Length = r.ReadInt32();
                Rate = r.ReadUInt32();
                LoopStart = r.ReadInt32();
                LoopEnd = r.ReadInt32();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool UnpackExtended(BigEndianBinaryReader r)
        {
            try
            {
                r.Skip(4);
                int channels = r.ReadInt32();
                Stereo = channels == 2;
                Rate = r.ReadUInt32();
                LoopStart = r.ReadInt32();
                LoopEnd = r.ReadInt32();
                byte headerType = r.ReadByte();
                r.Skip(1);
                int frames = r.ReadInt32();

                if (headerType == 0xfe)
                {
                    r.Skip(10);
                    r.Skip(4);
                    uint format = r.ReadUInt32();
                    r.Skip(12);
                    short compId = r.ReadInt16();

                    if (format != MacTypes.FourCC('t', 'w', 'o', 's') || compId != -1)
                    {
                        return false;
                    }

                    mSigned8Bits = true;
                    r.Skip(4);
                }
                else
                {
                    r.Skip(22);
                }

                short sampleSize = r.ReadInt16();
                BitsPerSample = sampleSize == 16 ? 16 : 8;
                BytesPerFrame = (BitsPerSample == 16 ? 2 : 1) * (Stereo ? 2 : 1);
                Length = checked(frames * BytesPerFrame);
                LittleEndian = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }
}
