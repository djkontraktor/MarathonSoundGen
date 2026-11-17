using System;
using System.IO;

namespace MarathonSoundGen
{
    public class ForkViewStream : Stream
    {

        #region Public Properties

        public override bool CanRead
        {
            get
            {
                return mBase.CanRead;
            } 
        }

        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override long Length
        {
            get
            {
                return mLength;
            }
        }

        public override long Position
        {
            get
            {
                return mPosition;
            }
            set
            {
                Seek(value, SeekOrigin.Begin);
            }
        }

        #endregion

        #region Private Properties

        private readonly Stream mBase;
        private readonly long mStart; 
        private readonly long mLength;
        private readonly bool mLeaveOpen;
        private long mPosition;

        #endregion

        #region Constructor

        public ForkViewStream(Stream stream, long start, long length, bool leaveOpen)
        {
            mBase = stream;
            mStart = start;
            mLength = length;
            mLeaveOpen = leaveOpen;
            mPosition = stream.Position - start;
        }

        #endregion

        #region Public Members

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (mPosition >= mLength)
            {
                return 0;
            }

            count = (int)Math.Min(count, mLength - mPosition);
            mBase.Position = mStart + mPosition;
            int n = mBase.Read(buffer, offset, count);
            mPosition += n;
            return n;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long p = origin == SeekOrigin.Begin ? offset : origin == SeekOrigin.Current ? mPosition + offset : mLength + offset;

            if (p < 0 || p > mLength)
            {
                throw new IOException("Seek outside fork.");
            }

            mPosition = p;
            return p;
        }

        public override void Flush()
        {

        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] b, int o, int c)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Private/Protected Members

        protected override void Dispose(bool disposing)
        {
            if (disposing && !mLeaveOpen)
            {
                mBase.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

    }
}
