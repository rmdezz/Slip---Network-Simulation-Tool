using System;
using System.Windows;
using System.Windows.Controls;
using static Slip.Utils.Utils;

namespace Slip.Utils
{
    internal static class SliderUtils
    {
        internal static void UpdateLabelFromSlider(Label label, Slider slider, ShowValue showValue)
        {
            if (label == null || slider == null) return;
            showValue(label, Math.Round(slider.Value, 2));
            //label.Content = Math.Round(slider.Value, 2) + " ms";
        }

        internal static void ApplySliderValue(Button applyButton, TextBox valueTextbox,
            Label valueLabel, Slider valueSlider, ValidateInput validateInput, ShowValue showValue)
        {
            // Check if elements have been properly initialized
            if (applyButton == null || valueTextbox == null || valueLabel == null || valueSlider == null) return;

            // Check if user input is valid

            if (!validateInput(valueTextbox.Text))
            {
                // Text is NOT a valid number
                MessageBox.Show("Input is not valid.");
                return;
            }

            double value = Math.Round(Convert.ToDouble(valueTextbox.Text), 2);

            // Text is a valid number

            // Check if number is greater than slider's max
            if (value > valueSlider.Maximum)
            {
                // Set new max
                valueSlider.Maximum = value;
            }

            // Hide helper elements
            valueTextbox.Visibility = Visibility.Collapsed;
            applyButton.Visibility = Visibility.Collapsed;

            // Apply changes
            valueSlider.Value = value;
            //valueLabel.Content = value + " ms";
            showValue(valueLabel, value);

            // Enable slider
            valueSlider.IsEnabled = true;

            // Clear text
            valueTextbox.Text = "";

            // Show new value
            valueLabel.Visibility = Visibility.Visible;
        }

    }
}
