using System;

namespace MarathonSoundGen
{
    public static class SoundsUtils
    {
        public static byte[] OpenM1SoundFile(string filePath, out SoundDefinition definition)
        {
            using (SoundsFile soundFile = new M1SoundsFile())
            {
                // Extensionless
                MacFileSpecifier file = new MacFileSpecifier(filePath);

                if (!soundFile.Open(file))
                {
                    throw new InvalidOperationException("No valid resource file was found.");
                }

                definition = soundFile.GetSoundDefinition(source: 0, soundIndex: 100);

                byte[] pcmData = definition == null ? null : soundFile.GetSoundData(definition, permutation: 0);

                return pcmData;
            }
        }

        public static byte[] OpenM2SoundFile(string filePath, out SoundDefinition definition)
        {
            using (SoundsFile soundFile = new M2SoundsFile())
            {
                // Compatible with extension .sndA
                MacFileSpecifier file = new MacFileSpecifier(filePath);

                if (!soundFile.Open(file))
                {
                    throw new InvalidOperationException("The sound file could not be opened.");
                }

                definition = soundFile.GetSoundDefinition(source: 0, soundIndex: 10);

                if (definition == null)
                {
                    throw new InvalidOperationException("The sound definition was not found.");
                }

                byte[] pcmData = soundFile.GetSoundData(definition, permutation: 0);

                if (pcmData == null)
                {
                    throw new InvalidOperationException("The sound data could not be loaded.");
                }

                return pcmData;
            }
        }
    }
}
