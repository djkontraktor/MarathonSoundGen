using System;

namespace MarathonSoundGen
{
    public class MacResource
    {

        #region Public Properties

        public bool IsLoaded
        {
            get
            {
                return mData != null;
            }
        }

        public int Length
        {
            get
            {
                return mData == null ? 0 : mData.Length;
            }
        }

        public byte[] Data
        {
            get
            {
                return mData;
            }
        }

        #endregion

        #region Private Properties

        private byte[] mData;

        #endregion

        #region Public Members

        public void Unload()
        {
            mData = null; 
        }

        public void SetData(byte[] data)
        {
            mData = data ?? throw new ArgumentNullException(nameof(data));
        }

        #endregion

    }
}
