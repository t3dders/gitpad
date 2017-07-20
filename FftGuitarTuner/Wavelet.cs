using System.Runtime.InteropServices;

namespace Wavelet
{
    class Pitchtracker
    {
        public static int counter = 1;

        //[DllImport("dywapitchtrack.dll", CallingConvention = CallingConvention.Cdecl)]
        [StructLayout(LayoutKind.Sequential)]
        public struct dywapitchtracker //static extern?
        {
            public double _prevPitch;
            public int _pitchConfidence;
        }
        [DllImport("dywapitchtrack.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int dywapitch_neededsamplecount(int minFreq);
        [DllImport("dywapitchtrack.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dywapitch_inittracking(ref dywapitchtracker pitchtracker); //<- and \/: dywapitchtracker* 
        [DllImport("dywapitchtrack.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double dywapitch_computepitch(ref dywapitchtracker pitchtracker, double[] samples, int startsample, int samplecount); //double*
    }
}