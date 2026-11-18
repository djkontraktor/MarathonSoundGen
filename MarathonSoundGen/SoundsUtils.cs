using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;

namespace MarathonSoundGen
{
    public static class SoundsUtils
    {

        #region Public Members

        public static void OpenM1SoundFile(string filePath)
        {
            using (SoundsFileRaw soundFile = new M1SoundsFileRaw())
            {
                //// Extensionless
                //MacFileSpecifier file = new MacFileSpecifier(filePath);

                //if (!soundFile.Open(file))
                //{
                //    throw new InvalidOperationException("No valid resource file was found.");
                //}

                //int soundIndex = 1;

                //definition = soundFile.GetSoundDefinition(source: 0, soundIndex);

                //int permutation = 0;

                //byte[] pcmData = definition == null ? null : soundFile.GetSoundData(definition, permutation);

                //header = soundFile.GetSoundHeader(definition, permutation);

                //return pcmData;
            }
        }

        public static List<SoundDefinition> OpenM2SoundFile(string filePath)
        {
            List<SoundDefinition> results = new List<SoundDefinition>();

            using (SoundsFileRaw soundFile = new M2SoundsFileRaw())
            {
                // Compatible with extension .sndA
                MacFileSpecifier file = new MacFileSpecifier(filePath);

                if (!soundFile.Open(file))
                {
                    throw new InvalidOperationException("The sound file could not be opened.");
                }

                for (int source = 0; source < soundFile.SourceCount; source++)
                {
                    foreach (int soundIndex in soundFile.GetSoundIndices(source))
                    {
                        SoundDefinitionRaw definition = soundFile.GetSoundDefinition(source, soundIndex);

                        if (definition == null)
                        {
                            continue;
                        }

                        SoundDefinition maraSoundDefinition = new SoundDefinition
                        {
                            Source = source,
                            SoundIndex = soundIndex,
                            Definition = definition,
                        };

                        int permutationCount = GetValidPermutationCount(definition);

                        for (int permutation = 0; permutation < permutationCount; permutation++)
                        {
                            SoundsFileHeader header = soundFile.GetSoundHeader(definition, permutation);

                            if (header == null)
                            {
                                continue;
                            }

                            byte[] data = soundFile.GetSoundData(definition, permutation);

                            if (data == null)
                            {
                                continue;
                            }

                            maraSoundDefinition.Permutations.Add(new SoundPermutation
                            {
                                Source = source,
                                SoundIndex = soundIndex,
                                Permutation = permutation,
                                Definition = definition,
                                Header = header,
                                Data = data,
                            });
                        }

                        results.Add(maraSoundDefinition);
                    }
                }
            }

            return results;
        }

        public static void PlaySound(byte[] soundData, SoundsFileHeader header)
        {
            if (soundData == null)
            {
                throw new ArgumentNullException(nameof(soundData));
            }

            if (header == null)
            {
                throw new ArgumentNullException(nameof(header));
            }

            try
            {
                using (MemoryStream waveStream = CreateWaveStream(soundData, header))
                using (SoundPlayer player = new SoundPlayer(waveStream))
                {
                    player.Load();
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Private Members

        private static int GetValidPermutationCount(SoundDefinitionRaw definition)
        {
            if (definition == null)
            {
                return 0;
            }

            int count = definition.Permutations;

            if (count < 0)
            {
                return 0;
            }

            // M2 populates Sounds with one header per permutation.
            // M1 does not populate this collection, so do not clamp
            // against Sounds.Count when it is empty.
            if (definition.Sounds.Count > 0)
            {
                count = Math.Min(count, definition.Sounds.Count);
            }

            return count;
        }

        private static MemoryStream CreateWaveStream(byte[] soundData, SoundsFileHeader header)
        {
            int channelCount = header.Stereo ? 2 : 1;

            // The System 7 sample rate is stored as unsigned 16.16
            // fixed-point. For example, 22050 Hz is 22050 << 16.
            int sampleRate = checked((int)(header.Rate >> 16));

            if (sampleRate <= 0)
            {
                throw new InvalidDataException("The sound header contains an invalid sample rate.");
            }

            int blockAlign = checked(channelCount * header.BitsPerSample / 8);

            int byteRate = checked(sampleRate * blockAlign);

            MemoryStream stream = new MemoryStream(checked(44 + soundData.Length));

            BinaryWriter writer = new BinaryWriter(stream, Encoding.ASCII, true);

            try
            {
                // RIFF header
                writer.Write(Encoding.ASCII.GetBytes("RIFF"));
                writer.Write(checked(36 + soundData.Length));
                writer.Write(Encoding.ASCII.GetBytes("WAVE"));

                // PCM format chunk
                writer.Write(Encoding.ASCII.GetBytes("fmt "));

                writer.Write(16);             // PCM fmt chunk size
                writer.Write((short)1);       // PCM format
                writer.Write((short)channelCount);
                writer.Write(sampleRate);
                writer.Write(byteRate);
                writer.Write((short)blockAlign);
                writer.Write((short)header.BitsPerSample);

                // PCM data chunk
                writer.Write(Encoding.ASCII.GetBytes("data"));

                writer.Write(soundData.Length);
                writer.Write(soundData);
                writer.Flush();

                stream.Position = 0;
                return stream;
            }
            catch
            {
                stream.Dispose();
                throw;
            }
            finally
            {
                writer.Dispose();
            }
        }

        #endregion

    }
}
