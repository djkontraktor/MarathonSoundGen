using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;

namespace MarathonSoundGen
{
    public static class SoundsUtils
    {

        private static MemoryStream mWaveStream = new MemoryStream();
        private static SoundPlayer mPlayer = new SoundPlayer(mWaveStream);

        #region Public Members

        public static void OpenM1SoundFile(string filePath)
        {
            using (SoundsFile soundFile = new M1SoundsFile())
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

        public static List<MaraSoundDefinition> OpenM2SoundFile(string filePath)
        {
            List<MaraSoundDefinition> results = new List<MaraSoundDefinition>();

            using (SoundsFile soundFile = new M2SoundsFile())
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
                        SoundDefinition definition = soundFile.GetSoundDefinition(source, soundIndex);

                        if (definition == null)
                        {
                            continue;
                        }

                        MaraSoundDefinition maraSoundDefinition = new MaraSoundDefinition
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

                            maraSoundDefinition.Permutations.Add(new MaraSoundPermutation
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

        public static void StartAudioStreamer()
        {
            mPlayer.Load();
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
                mWaveStream = CreateWaveStream(soundData, header);
                mPlayer.PlaySync();
            }
            catch (Exception ex)
            {

            }
        }

        public static void StopAudioStreamer()
        {
            mPlayer.Dispose();
            mWaveStream.Dispose();
        }

        #endregion

        #region Private Members

        private static int GetValidPermutationCount(SoundDefinition definition)
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

            int bitsPerSample;

            switch (header.AudioFormat)
            {
                case AudioFormat._8_bit:
                    bitsPerSample = 8;
                    break;

                case AudioFormat._16_bit:
                    bitsPerSample = 16;
                    break;

                default:
                    throw new NotSupportedException("Unsupported audio format: " + header.AudioFormat);
            }

            // The System 7 sample rate is stored as unsigned 16.16
            // fixed-point. For example, 22050 Hz is 22050 << 16.
            int sampleRate = checked((int)(header.Rate >> 16));

            if (sampleRate <= 0)
            {
                throw new InvalidDataException("The sound header contains an invalid sample rate.");
            }

            int blockAlign = checked(channelCount * bitsPerSample / 8);

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
                writer.Write((short)bitsPerSample);

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
