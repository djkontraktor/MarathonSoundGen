using System.Collections.Generic;

namespace MarathonSoundGen
{
    public class MaraSoundDefinition
    {
        public int Source { get; set; }
        public int SoundIndex { get; set; }
        public SoundDefinition Definition { get; set; }
        public List<MaraSoundPermutation> Permutations { get; private set; }

        public MaraSoundDefinition()
        {
            Permutations = new List<MaraSoundPermutation>();
        }
    }
}
