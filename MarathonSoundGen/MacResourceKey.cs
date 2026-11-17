using System;

namespace MarathonSoundGen
{
    internal struct MacResourceKey : IEquatable<MacResourceKey>
    {

        #region Public Properties

        public readonly uint Type;
        public readonly short Id;

        #endregion

        #region Constructor

        public MacResourceKey(uint type, short id)
        {
            Type = type;
            Id = id;
        }

        #endregion

        #region Public Members

        public bool Equals(MacResourceKey o)
        {
            return Type == o.Type && Id == o.Id;
        }

        public override bool Equals(object o)
        {
            return o is MacResourceKey && Equals((MacResourceKey)o);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Type * 397) ^ Id;
            }
        }

        #endregion

    }
}
