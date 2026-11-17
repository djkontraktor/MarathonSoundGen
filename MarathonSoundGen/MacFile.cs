using System;
using System.IO;

namespace MarathonSoundGen
{
    public class MacFile : IDisposable
    {

        #region Public Properties

        public bool IsOpen
        {
            get
            {
                return mStream != null;
            }
        }

        public int Error
        {
            get
            {
                return mError;
            }
        }

        public long Position
        {
            get
            {
                EnsureOpen();
                return mStream.Position - mForkOffset;
            }
        }

        public long Length
        {
            get
            {
                EnsureOpen();
                return mForkLength;
            }
        }

        #endregion

        #region Private/Internal Properties

        private FileStream mStream;
        private long mForkOffset;
        private long mForkLength;
        private int mError;

        internal Stream BaseStream
        {
            get
            {
                EnsureOpen();
                return new ForkViewStream(mStream, mForkOffset, mForkLength, true);
            }
        }

        #endregion

        #region Public Members

        public bool SetPosition(int position)
        {
            if (mStream == null || position < 0 || position > mForkLength)
            {
                return false;
            }

            mStream.Position = mForkOffset + position;
            return true;
        }

        public bool Read(int count, byte[] buffer)
        {
            return Read(count, buffer, 0);
        }

        public bool Read(int count, byte[] buffer, int offset)
        {
            if (mStream == null || buffer == null || count < 0 || offset < 0 || offset > buffer.Length - count)
            {
                return false;
            }

            if (Position + count > mForkLength)
            {
                return false;
            }

            int total = 0;

            while (total < count)
            {
                int read = mStream.Read(buffer, offset + total, count - total);

                if (read == 0)
                {
                    return false;
                }

                total += read;
            }

            return true;
        }

        public bool Close()
        {
            if (mStream != null)
            {
                mStream.Dispose();
            }

            mStream = null;
            mForkOffset = 0;
            mForkLength = 0;
            mError = 0;

            return true;
        }

        public void Dispose()
        {
            Close();
        }

        #endregion

        #region Private/Internal Members

        private void EnsureOpen()
        {
            if (mStream == null)
            {
                throw new ObjectDisposedException(nameof(MacFile));
            }
        }

        internal void Attach(FileStream stream, long forkOffset, long forkLength)
        {
            Close();
            mStream = stream;
            mForkOffset = forkOffset;
            mForkLength = forkLength;
            mStream.Position = forkOffset;
            mError = 0;
        }

        #endregion
        
    }
}
