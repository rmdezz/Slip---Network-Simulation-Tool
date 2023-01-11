using System.Windows.Controls;

namespace Slip.Utils
{
    internal static class ApplicationState
    {
        internal static bool IsProgramRunning(Button startButton)
        {
            return startButton.Content.ToString() == "Stop";
        }
    }
}