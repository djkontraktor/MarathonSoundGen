using System;
using System.IO;

namespace MarathonSoundGen
{
    public class BigEndianBinaryReader : IDisposable
    {

        #region Public Properties

        public long Position
        {
            get
            {
                return mStream.Position;
            }
            set
            {
                mStream.Position = value;
            }
        }

        public long Length
        {
            get
            {
                return mStream.Length;
            }
        }

        public Stream BaseStream
        {
            get
            {
                return mStream;
            }
        }

        #endregion

        #region Private Properties

        private readonly Stream mStream;
        private readonly bool mLeaveOpen;

        #endregion

        #region Constructor

        public BigEndianBinaryReader(Stream stream, bool leaveOpen = false)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!stream.CanRead)
            {
                throw new ArgumentException("Stream must be readable.", nameof(stream));
            }

            mStream = stream;
            mLeaveOpen = leaveOpen;
        }

        #endregion

        #region Public Members

        public byte ReadByte()
        {
            int value = mStream.ReadByte();

            if (value < 0)
            {
                throw new EndOfStreamException();
            }

            return (byte)value;
        }

        public short ReadInt16()
        {
            return unchecked((short)ReadUInt16());
        }

        public ushort ReadUInt16()
        {
            return (ushort)((ReadByte() << 8) | ReadByte());
        }

        public int ReadInt32()
        {
            return unchecked((int)ReadUInt32());
        }

        public uint ReadUInt32()
        {
            return ((uint)ReadByte() << 24) | ((uint)ReadByte() << 16) | ((uint)ReadByte() << 8) | ReadByte();
        }

        public byte[] ReadBytesExactly(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            byte[] data = new byte[count];
            int total = 0;

            while (total < count)
            {
                int read = mStream.Read(data, total, count - total);

                if (read == 0)
                {
                    throw new EndOfStreamException();
                }

                total += read;
            }

            return data;
        }

        public void Skip(long count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            long target = checked(mStream.Position + count);

            if (target > mStream.Length)
            {
                throw new EndOfStreamException();
            }

            mStream.Position = target;
        }

        public void Dispose()
        {
            if (!mLeaveOpen)
            {
                mStream.Dispose();
            }
        }

        #endregion

    }
}
