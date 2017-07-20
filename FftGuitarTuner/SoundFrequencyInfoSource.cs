using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SoundCapture;
using SoundAnalysis;

using Wavelet;

namespace FftGuitarTuner
{
    class SoundFrequencyInfoSource : FrequencyInfoSource
    {
        SoundCaptureDevice device;
        Adapter adapter;

        internal SoundFrequencyInfoSource(SoundCaptureDevice device)
        {
            this.device = device;
        }

        public override void Listen()
        {
            adapter = new Adapter(this, device);
            adapter.Start();
        }

        public override void Stop()
        {
            adapter.Stop();
        }

        class Adapter : SoundCaptureBase
        {
            SoundFrequencyInfoSource owner;

            const double MinFreq = 60;
            const double MaxFreq = 1300;

            internal Adapter(SoundFrequencyInfoSource owner, SoundCaptureDevice device)
                : base(device)
            {
                this.owner = owner;
            }

            protected override void ProcessData(short[] data)
            {
                double[] x = new double[data.Length];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = data[i] / 32768.0;
                }

                if (Wavelet.Pitchtracker.counter == 0)
                {
                    double freq = FrequencyUtils.FindFundamentalFrequency(x, SampleRate, MinFreq, MaxFreq);
                    owner.OnFrequencyDetected(new FrequencyDetectedEventArgs(freq));
                }
                else
                {
                    Wavelet.Pitchtracker.dywapitchtracker pitchtracker = new Wavelet.Pitchtracker.dywapitchtracker();
                    Wavelet.Pitchtracker.dywapitch_inittracking(ref pitchtracker);
                    double freq = Wavelet.Pitchtracker.dywapitch_computepitch(ref pitchtracker, x, 0, x.Length);
                    owner.OnFrequencyDetected(new FrequencyDetectedEventArgs(freq));
                }
            }

            protected override void ProcessData(double[] data)
            {
                /*
                double[] x = new double[data.Length];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = data[i] / 32768.0;
                }
                */
                 
                Wavelet.Pitchtracker.dywapitchtracker pitchtracker = new Wavelet.Pitchtracker.dywapitchtracker();
                Wavelet.Pitchtracker.dywapitch_inittracking(ref pitchtracker);
                double freq = Wavelet.Pitchtracker.dywapitch_computepitch(ref pitchtracker, data, 0, data.Length);
                owner.OnFrequencyDetected(new FrequencyDetectedEventArgs(freq));
            }
        }
    }
}
