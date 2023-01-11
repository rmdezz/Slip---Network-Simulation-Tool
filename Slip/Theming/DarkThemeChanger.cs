using System;
using System.Windows;

namespace Slip.Theming
{
    public class DarkThemeChanger : IThemeChanger
    {
        public void ChangeTheme()
        {
            // Set the current theme to dark theme
            Application.Current.Resources.MergedDictionaries[0].Source =
                new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/materialdesigntheme.dark.xaml",
                    UriKind.Absolute);
        }
    }
}