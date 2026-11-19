using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSoundGen
{
    public sealed class OwnedSampleProvider : IDisposable
    {
        private readonly IDisposable[] mOwnedResources;
        private bool mDisposed;

        public ISampleProvider Provider { get; private set; }

        public OwnedSampleProvider(
            ISampleProvider provider,
            params IDisposable[] ownedResources)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            Provider = provider;

            mOwnedResources =
                ownedResources ?? new IDisposable[0];
        }

        public void Dispose()
        {
            if (mDisposed)
            {
                return;
            }

            mDisposed = true;
            Provider = null;

            /*
             * Dispose in the supplied order. Pass WaveFileReader before its
             * underlying MemoryStream when constructing this object.
             */
            for (int index = 0;
                 index < mOwnedResources.Length;
                 index++)
            {
                IDisposable resource = mOwnedResources[index];

                if (resource != null)
                {
                    resource.Dispose();
                }
            }
        }
    }
}
