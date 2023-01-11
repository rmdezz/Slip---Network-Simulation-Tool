using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Slip.Theming;
using Slip.Utils;

namespace Slip.EventHandlers
{
    public class ButtonEventHandlers
    {
        private MainWindow _mainWindow;
        private bool stopped = true;
        private const string LIGHT_THEME_URI = "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/materialdesigntheme.light.xaml";
        
        internal bool Stopped
        {
            get { return stopped; }
            set { stopped = value; }
        }

        public ButtonEventHandlers(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitButtonEventHandlers();
        }

        private void InitButtonEventHandlers()
        {
            StartEventHandler();
            ChangeThemeEventHandler();
            
            TrafficShaperEventHandlers();
            ShuffleEventHandlers();
            DuplicateEventHandlers();
            EncryptEventHandlers();
            ThrottleEventHandlers();
            DropEventHandlers();
            LagEventHandlers();
        }

        private void LagEventHandlers()
        {
            OnClick(_mainWindow.lagChanceButton, ApplyLagChance_OnClick);
        }

        private void DropEventHandlers()
        {
            OnClick(_mainWindow.dropChanceButton, DropChanceButtonOnClick);
        }

        private void ThrottleEventHandlers()
        {
            OnClick(_mainWindow.throttleChanceButton, ThrottleChanceButtonOnClick);
        }

        private void EncryptEventHandlers()
        {
            OnClick(_mainWindow.encryptChanceButton, EncryptChanceButtonOnClick);
        }

        private void DuplicateEventHandlers()
        {
            OnClick(_mainWindow.duplicateChanceButton, DuplicateChanceButton_OnClick);
        }

        private void ShuffleEventHandlers()
        {
            OnClick(_mainWindow.shuffleChanceButton, ShuffleChanceButton_OnClick);
        }

        private void TrafficShaperEventHandlers()
        {
            OnClick(_mainWindow.tShaperChanceButton, TShaperChanceButton_OnClick);
        }

        private void ChangeThemeEventHandler()
        {
            OnClick(_mainWindow.changeThemeButton, ChangeThemeButton_OnClick);
        }

        private void StartEventHandler()
        {
            OnClick(_mainWindow.startButton, StartButton_OnClick);
        }

        private void OnClick(Button button, RoutedEventHandler eventHandler)
        {
            button.Click += eventHandler;
        }

        private void OnClick(ToggleButton toggleButton, RoutedEventHandler eventHandler)
        {
            toggleButton.Click += eventHandler;
        }
        

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ApplicationState.IsProgramRunning(_mainWindow.startButton))
            {
                stopped = _mainWindow.SimulationController.StopSimulation();
            }
            else
            {
                string filter = Filter.GetFilter(_mainWindow.CustomCheckbox.IsChecked.Value,
                    _mainWindow.customFilter.Text, _mainWindow.ModuleConfigManager.GetFilter());
                
                if (!Filter.ValidateFilter(filter)) return;

                if (!_mainWindow.SimulationController.StartSimulation(filter, ref stopped))
                {
                    MessageBox.Show("Failed to start program. Try again later.");
                }
            }
        }
        private void ChangeThemeButton_OnClick(object sender, RoutedEventArgs e)
        {
            /*
             * The main responsibility of the ChangeThemeButton_OnClick method is to instantiate
             * the appropriate theme changer and background changer objects, and then call
             * the ChangeTheme and ChangeBackground methods.
             *
             * The theme changer and background changer classes have a single responsibility,
             * to change the theme and change the background color of the tabControl
             * respectively, this way it makes the code more maintainable, testable, and extendable.
             */
            
            IThemeChanger themeChanger;
            IBackgroundChanger backgroundChanger;
            
            // Currently it's light, set to dark
            if (Application.Current.Resources.MergedDictionaries[0].Source.AbsoluteUri == LIGHT_THEME_URI)
            {
                themeChanger = new DarkThemeChanger();
                backgroundChanger = new BackgroundChanger(_mainWindow.tabControl, "#FF1E1E1E");
            }
            
            // It's dark, set to light theme
            else
            {
                themeChanger = new LightThemeChanger();
                backgroundChanger = new BackgroundChanger(_mainWindow.tabControl, "#ECECEC");
                
            }
            
            themeChanger.ChangeTheme();
            backgroundChanger.ChangeBackground();
        }
        
        private void ApplyLagChance_OnClick(object sender, RoutedEventArgs e)
        {
            SliderUtils.ApplySliderValue(_mainWindow.lagChanceButton, _mainWindow.lagTextbox,
                _mainWindow.lagLabel, _mainWindow.lagSlider, Utils.Utils.CheckIfNumber, Utils.Utils.ShowLagValue);
        }
        
        private void DropChanceButtonOnClick(object sender, RoutedEventArgs e)
        {
            SliderUtils.ApplySliderValue(_mainWindow.dropChanceButton, _mainWindow.dropTextbox,
                _mainWindow.dropLabel, _mainWindow.dropChanceSlider, Utils.Utils.CheckIfNumberAndWithinRange,
                Utils.Utils.ShowChanceValue);
        }
        
        private void ThrottleChanceButtonOnClick(object sender, RoutedEventArgs e)
        {
            SliderUtils.ApplySliderValue(_mainWindow.throttleChanceButton, _mainWindow.throttleTextbox,
                _mainWindow.throttleLabel, _mainWindow.throttleChanceSlider,
                Utils.Utils.CheckIfNumberAndWithinRange, Utils.Utils.ShowChanceValue);
        }

        private void EncryptChanceButtonOnClick(object sender, RoutedEventArgs e)
        {
            SliderUtils.ApplySliderValue(_mainWindow.encryptChanceButton, _mainWindow.encryptTextbox,
                _mainWindow.encryptLabel, _mainWindow.encryptChanceSlider,
                Utils.Utils.CheckIfNumberAndWithinRange, Utils.Utils.ShowChanceValue);
        }
        
        private void ShuffleChanceButton_OnClick(object sender, RoutedEventArgs e)
        {
            SliderUtils.ApplySliderValue(_mainWindow.shuffleChanceButton, _mainWindow.shuffleTextbox,
                _mainWindow.shuffleLabel, _mainWindow.shuffleChanceSlider, Utils.Utils.CheckIfNumberAndWithinRange,
                Utils.Utils.ShowChanceValue);
            _mainWindow.shuffleMinPacketsLabel.Visibility = Visibility.Visible;
        }

        private void DuplicateChanceButton_OnClick(object sender, RoutedEventArgs e)
        {
            SliderUtils.ApplySliderValue(_mainWindow.duplicateChanceButton, _mainWindow.duplicateTextbox,
                _mainWindow.duplicateLabel, _mainWindow.duplicateChanceSlider, Utils.Utils.CheckIfNumberAndWithinRange,
                Utils.Utils.ShowChanceValue);
        }
        
        private void TShaperChanceButton_OnClick(object sender, RoutedEventArgs e)
        {
            SliderUtils.ApplySliderValue(_mainWindow.tShaperChanceButton,
                _mainWindow.trafficShaperTextbox, _mainWindow.trafficShaperLabel,
                _mainWindow.trafficShaperChanceSlider, Utils.Utils.CheckIfNumberAndWithinRange, Utils.Utils.ShowChanceValue);
        }
    }
}