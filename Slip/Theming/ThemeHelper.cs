using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace Slip.Theming
{
    public static class ThemeHelper
    {
        internal static void SetTheme(byte red, byte green, byte blue)
        {
            // Set the primary and secondary colors of the theme to a custom color
            Color customColor = Color.FromRgb(red, green, blue);
            
            // Create a helper object for managing the theme
            PaletteHelper themeManager = new PaletteHelper();
            
            // Get the current theme
            ITheme theme = themeManager.GetTheme();
            
            // Set both the primary and secondary colors of the theme to the custom color
            theme.SetPrimaryColor(customColor);
            theme.SetSecondaryColor(customColor);
            
            // Update the theme with the new primary and secondary colors
            themeManager.SetTheme(theme);
        }
    }
}