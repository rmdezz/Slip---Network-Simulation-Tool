using System.Windows;
using System.Windows.Controls;

namespace Slip.Utils
{
    internal static class Utils
    {
        internal delegate bool ValidateInput(string input);
        internal delegate void ShowValue(Label label, double value);

        internal static bool CheckIfNumber(string input)
        {
            double value;
            return double.TryParse(input, out value);
        }

        internal static bool CheckIfNumberAndWithinRange(string input)
        {
            double number;

            if (!double.TryParse(input, out number)) // input is NOT a valid number
            {
                return false;
            }

            return number >= 0 && number <= 100;
        }

        internal static void ShowLagValue(Label label, double value)
        {
            label.Content = value + " ms";
        }

        internal static void ShowChanceValue(Label label, double value)
        {
            label.Content = value + " %";
        }

        internal static void ShowHelperElements(Label label, Button button, TextBox textBox, Slider slider)
        {
            if (label == null || textBox == null || slider == null) return;

            // Show helper elements
            textBox.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;

            // Disable slider
            slider.IsEnabled = false;

            // Hide show value element
            label.Visibility = Visibility.Hidden;
        }

    }
}
