using System;
using System.Windows;

namespace Slip.Theming
{
    public class LightThemeChanger : IThemeChanger
    {
        public void ChangeTheme()
        {
            // Set the current theme to light theme
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri
            ("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/materialdesigntheme.light.xaml",
                UriKind.Absolute);
        }
    }
}
