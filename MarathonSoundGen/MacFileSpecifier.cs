using System;
using System.IO;

namespace MarathonSoundGen
{
    public class MacFileSpecifier
    {

        #region Public Properties

        public string Path { get; private set; }

        #endregion

        #region Constructor

        public MacFileSpecifier(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            Path = System.IO.Path.GetFullPath(path);
        }

        #endregion

        #region Public Members

        public bool Open(MacFile file, bool writable = false)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            try
            {
                FileStream fs = new FileStream(Path, FileMode.Open, writable ? FileAccess.ReadWrite : FileAccess.Read, FileShare.ReadWrite);
                long offset = 0, length = fs.Length;
                long dataOffset, dataLength;

                if (MacContainerFormats.TryFindAppleSingleFork(fs, false, out dataOffset, out dataLength))
                {
                    offset = dataOffset;
                    length = dataLength;
                }
                else
                {
                    long dl, rl;

                    if (MacContainerFormats.TryReadMacBinary(fs, out dl, out rl))
                    {
                        offset = 128;
                        length = dl;
                    }
                }

                file.Attach(fs, offset, length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Open(MacResourceFile file, bool writable = false)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (writable)
            {
                return false;
            }

            return file.Open(Path);
        }

        #endregion

    }
}
