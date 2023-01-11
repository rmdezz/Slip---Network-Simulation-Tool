using System;
using System.Runtime.InteropServices;
using System.Windows;

// A namespace can only contain type declarations such as classes, structs, interfaces, and enums.
namespace Slip
{
    internal static class WinDivert
    {
        /*
         * In this case, since fields are already within an internal class,
         * it is already accessible within the same assembly and adding the
         * internal keyword is redundant.
         */
        [DllImport("kernel32.dll")]
        internal static extern bool SetDllDirectory(string lpPathName);

        [DllImport("WinDivert.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern bool WinDivertHelperCompileFilter(
            [MarshalAs(UnmanagedType.LPStr)] string filter,
            WindivertLayer layer,
            IntPtr obj,
            uint objLen,
            out IntPtr errorStr,
            out uint errorPos
        );

        internal enum WindivertLayer
        {
            WindivertLayerNetwork = 0,
            WindivertLayerNetworkForward = 1
        }
        
        internal static bool CheckFilter(string filter)
        {
            WindivertLayer layer = WindivertLayer.WindivertLayerNetwork;
            IntPtr obj = IntPtr.Zero;
            uint objLen = 0;
            IntPtr errorStr;
            uint errorPos;

            bool success = WinDivertHelperCompileFilter(filter, layer, obj, objLen, out errorStr, out errorPos);

            if (!success)
            {
                string errorString = Marshal.PtrToStringAnsi(errorStr);
                MessageBox.Show(errorString);
            }

            return success;
        }
    }
}
