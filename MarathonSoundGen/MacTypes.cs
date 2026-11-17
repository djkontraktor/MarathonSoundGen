namespace MarathonSoundGen
{
    public static class MacTypes
    {

        #region Constants

        public const int None = -1;
        public const ushort UNone = 65535;
        public const int FixedFractionalBits = 16;
        public const int FixedOne = 1 << FixedFractionalBits;
        public const int FixedOneHalf = 1 << (FixedFractionalBits - 1);

        #endregion

        #region Public Members

        public static int IntegerToFixed(int value)
        {
            return checked(value << FixedFractionalBits);
        }

        public static int FixedIntegerPart(int value)
        {
            return value >> FixedFractionalBits;
        }

        public static double FixedToDouble(int value)
        {
            return value / (double)FixedOne;
        }

        public static uint FourCC(char a, char b, char c, char d)
        {
            return ((uint)(byte)a << 24) | ((uint)(byte)b << 16) | ((uint)(byte)c << 8) | (byte)d;
        }

        #endregion

    }
}
