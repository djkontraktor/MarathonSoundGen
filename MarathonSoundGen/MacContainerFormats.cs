using System.IO;

namespace MarathonSoundGen
{
    public static class MacContainerFormats
    {

        #region Public Members

        public static bool TryFindAppleSingleFork(Stream s, bool resourceFork, out long offset, out long length)
        {
            offset = length = 0;

            try
            {
                s.Position = 0;

                using (BigEndianBinaryReader r = new BigEndianBinaryReader(s, true))
                {
                    if (r.ReadUInt32() != 0x00051600 || r.ReadUInt32() != 0x00020000)
                    {
                        return false;
                    }

                    s.Position = 0x18;
                    int n = r.ReadUInt16();
                    uint wanted = resourceFork ? 2u : 1u;

                    for (int i = 0; i < n; i++)
                    {
                        uint id = r.ReadUInt32();
                        uint o = r.ReadUInt32();
                        uint l = r.ReadUInt32();

                        if (id == wanted)
                        {
                            offset = o;
                            length = l;
                            return true;
                        }
                    }
                }
            }
            catch
            {

            }

            return false;
        }

        public static bool TryReadMacBinary(Stream s, out long dataLength, out long resourceLength)
        {
            dataLength = resourceLength = 0;

            try
            {
                s.Position = 0;
                byte[] h = new byte[128];
                int n = s.Read(h, 0, 128);

                if (n != 128 || h[0] != 0 || h[1] > 63 || h[74] != 0 || h[123] > 0x81)
                {
                    return false;
                }

                ushort crc = 0;

                for (int i = 0; i < 124; i++)
                {
                    ushort data = (ushort)(h[i] << 8);

                    for (int j = 0; j < 8; j++)
                    {
                        crc = (ushort)(((data ^ crc) & 0x8000) != 0 ? (crc << 1) ^ 0x1021 : crc << 1);
                        data = (ushort)(data << 1);
                    }
                }

                if (crc != (ushort)((h[124] << 8) | h[125]))
                {
                    return false;
                }

                dataLength = ((long)h[83] << 24) | ((long)h[84] << 16) | ((long)h[85] << 8) | h[86];
                resourceLength = ((long)h[87] << 24) | ((long)h[88] << 16) | ((long)h[89] << 8) | h[90];
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
