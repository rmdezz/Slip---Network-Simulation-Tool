using System.Windows;
using System.Windows.Controls;
using Slip.Utils;

namespace Slip.EventHandlers
{
    internal class SliderEventHandlers
    {
        private MainWindow _mainWindow;

        public SliderEventHandlers(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            // Initialize event handlers
            InitSliderEventHandlers();
        }

        private void InitSliderEventHandlers()
        {
            LagEventHandlers();
            DropEventHandlers();
            ThrottleEventHandlers();
            EncryptEventHandlers();
            DuplicateEventHandlers();
            ShuffleEventHandlers();
            TrafficShaperEventHandlers();
        }

        private void TrafficShaperEventHandlers()
        {
            // Traffic Shaper
            OnValueChanged(_mainWindow.trafficShaperChanceSlider, TShaperChanceSlider_OnValueChanged);
        }

        private void ShuffleEventHandlers()
        {
            // Shuffle
            OnValueChanged(_mainWindow.shuffleChanceSlider, ShuffleSlider_OnValueChanged);
        }

        private void DuplicateEventHandlers()
        {
            // Duplicate
            OnValueChanged(_mainWindow.duplicateChanceSlider, DuplicateChanceSlider_OnValueChanged);
        }

        private void EncryptEventHandlers()
        {
            // Encrypt
            OnValueChanged(_mainWindow.encryptChanceSlider, EncryptChanceSlider_OnValueChanged);
        }

        private void ThrottleEventHandlers()
        {
            // Throttle
            OnValueChanged(_mainWindow.throttleChanceSlider, ThrottleChanceSlider_OnValueChanged);
        }

        private void DropEventHandlers()
        {
            // Drop
            OnValueChanged(_mainWindow.dropChanceSlider, DropChanceSlider_OnValueChanged);
        }

        private void LagEventHandlers()
        {
            // Lag
            OnValueChanged(_mainWindow.lagSlider, LagSlider_OnValueChanged);
        }

        private void OnValueChanged(Slider slider, RoutedPropertyChangedEventHandler<double> eventHandler)
        {
            slider.ValueChanged += eventHandler;
        }

        private void OnClick(Button button, RoutedEventHandler eventHandler)
        {
            button.Click += eventHandler;
        }
        
        private void LagSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderUtils.UpdateLabelFromSlider(_mainWindow.lagLabel, _mainWindow.lagSlider, Utils.Utils.ShowLagValue);
        }

        private void DropChanceSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderUtils.UpdateLabelFromSlider(_mainWindow.dropLabel, _mainWindow.dropChanceSlider,
                Utils.Utils.ShowChanceValue);
        }

        private void ThrottleChanceSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderUtils.UpdateLabelFromSlider(_mainWindow.throttleLabel,
                _mainWindow.throttleChanceSlider, Utils.Utils.ShowChanceValue);
        }

        private void EncryptChanceSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderUtils.UpdateLabelFromSlider(_mainWindow.encryptLabel, _mainWindow.encryptChanceSlider,
                Utils.Utils.ShowChanceValue);
        }

        private void ShuffleSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderUtils.UpdateLabelFromSlider(_mainWindow.shuffleLabel, _mainWindow.shuffleChanceSlider,
                Utils.Utils.ShowChanceValue);
        }

        private void DuplicateChanceSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderUtils.UpdateLabelFromSlider(_mainWindow.duplicateLabel,
                _mainWindow.duplicateChanceSlider, Utils.Utils.ShowChanceValue);
        }
        
        private void TShaperChanceSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderUtils.UpdateLabelFromSlider(_mainWindow.trafficShaperLabel,
                _mainWindow.trafficShaperChanceSlider, Utils.Utils.ShowChanceValue);
        }
    }
}