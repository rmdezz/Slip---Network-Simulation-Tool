namespace Slip.Theming
{
    public class CustomThemeChanger : IThemeChanger
    {
        private byte red, green, blue;
        
        public CustomThemeChanger(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        public void ChangeTheme()
        {
            ThemeHelper.SetTheme(red, green, blue);
        }
    }
}