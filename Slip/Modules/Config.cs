using System.Runtime.InteropServices;

namespace Slip.Modules
{
    public enum SimulationType
    {
        Lag,
        Drop,
        Throttle,
        Duplicate,
        Shuffle,
        Encrypt,
        TrafficShaper
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct Config
    {
        [FieldOffset(0)]
        public bool enabled;
        [FieldOffset(1)]
        public bool inbound;
        [FieldOffset(2)]
        public bool outbound;
        [FieldOffset(3)]
        public float chance;        // All modules except traffic shaper
        [FieldOffset(7)]
        public float delay;        // Only used for the lag and throttle module (time)
        [FieldOffset(11)]
        public float num;         //   Only used for the duplicate (numCopies) and traffic shaper (speed limit) modules
        [FieldOffset(15)]
        public bool drop;        //    Only used for the throttle module
        [FieldOffset(16)]
        public SimulationType simulationType;
    }
}
