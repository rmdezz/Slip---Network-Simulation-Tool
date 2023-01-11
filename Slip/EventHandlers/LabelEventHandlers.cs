using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Slip.EventHandlers
{
    public class LabelEventHandlers
    {
        private MainWindow _mainWindow;
        
        public LabelEventHandlers(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitLabelEventHandlers();
        }

        private void InitLabelEventHandlers()
        {
            LagEventHandlers();
            DropEventHandlers();
            ThrottleEventHandlers();
            EncryptEventHandlers();
            ShuffleEventHandlers();
            DuplicateEventHandlers();
            TrafficShaperEventHandlers();
        }

        private void TrafficShaperEventHandlers()
        {
            OnMouseDoubleClick(_mainWindow.trafficShaperLabel, TrafficShaperLabel_OnMouseDoubleClick);
        }

        private void DuplicateEventHandlers()
        {
            OnMouseDoubleClick(_mainWindow.duplicateLabel, DuplicateLabel_OnMouseDoubleClick);
        }

        private void ShuffleEventHandlers()
        {
            OnMouseDoubleClick(_mainWindow.shuffleLabel, ShuffleLabel_OnMouseDoubleClick);
        }

        private void EncryptEventHandlers()
        {
            OnMouseDoubleClick(_mainWindow.encryptLabel, EncryptLabel_OnMouseDoubleClick);
        }

        private void ThrottleEventHandlers()
        {
            OnMouseDoubleClick(_mainWindow.throttleLabel, ThrottleLabel_OnMouseDoubleClick);
        }

        private void DropEventHandlers()
        {
            OnMouseDoubleClick(_mainWindow.dropLabel, DropLabel_OnMouseDoubleClick);
        }

        private void LagEventHandlers()
        {
            OnMouseDoubleClick(_mainWindow.lagLabel, LagValue_OnMouseDoubleClick);
        }

        private void OnMouseDoubleClick(Label label, MouseButtonEventHandler eventHandler)
        {
            label.MouseDoubleClick += eventHandler;
        }

        private void LagValue_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Utils.Utils.ShowHelperElements(_mainWindow.lagLabel, _mainWindow.lagChanceButton,
                _mainWindow.lagTextbox, _mainWindow.lagSlider);
        }

        private void DropLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Utils.Utils.ShowHelperElements(_mainWindow.dropLabel, _mainWindow.dropChanceButton,
                _mainWindow.dropTextbox, _mainWindow.dropChanceSlider);
        }

        private void ThrottleLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Utils.Utils.ShowHelperElements(_mainWindow.throttleLabel, _mainWindow.throttleChanceButton,
                _mainWindow.throttleTextbox, _mainWindow.throttleChanceSlider);
        }

        private void EncryptLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Utils.Utils.ShowHelperElements(_mainWindow.encryptLabel, _mainWindow.encryptChanceButton,
                _mainWindow.encryptTextbox, _mainWindow.encryptChanceSlider);
        }

        private void ShuffleLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Utils.Utils.ShowHelperElements(_mainWindow.shuffleLabel, _mainWindow.shuffleChanceButton,
                _mainWindow.shuffleTextbox, _mainWindow.shuffleChanceSlider);
            
            _mainWindow.shuffleMinPacketsLabel.Visibility = Visibility.Hidden;
        }
        
        private void DuplicateLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Utils.Utils.ShowHelperElements(_mainWindow.duplicateLabel, _mainWindow.duplicateChanceButton,
                _mainWindow.duplicateTextbox, _mainWindow.duplicateChanceSlider);
        }
        
        private void TrafficShaperLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Utils.Utils.ShowHelperElements(_mainWindow.trafficShaperLabel, _mainWindow.tShaperChanceButton,
                _mainWindow.trafficShaperTextbox, _mainWindow.trafficShaperChanceSlider);
        }
    }
}