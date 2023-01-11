using System.Windows.Controls;
using System.Windows.Media;

namespace Slip.Theming
{
    public class BackgroundChanger : IBackgroundChanger
    {
        private readonly TabControl _tabControl;
        private string colorValue;
        
        public BackgroundChanger(TabControl tabControl, string colorValue)
        {
            _tabControl = tabControl;
            this.colorValue = colorValue;
        }

        public void ChangeBackground()
        {
            // Create a solid color brush with the desired color
            SolidColorBrush brush = new SolidColorBrush((Color) ColorConverter.ConvertFromString(colorValue));
            _tabControl.Background = brush;
        }
    }
}