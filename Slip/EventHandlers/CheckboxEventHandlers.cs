using System.Windows;

namespace Slip.EventHandlers
{
    internal class CheckboxEventHandlers
    {
        private UiEventHandlers _uiEventHandlers;
        private MainWindow _mainWindow;
        
        internal CheckboxEventHandlers(UiEventHandlers uiEventHandlers, MainWindow mainWindow)
        {
            _uiEventHandlers = uiEventHandlers;
            _mainWindow = mainWindow;
            InitCheckboxEventHandlers();
        }

        private void InitCheckboxEventHandlers()
        {
            _mainWindow.CustomCheckbox.Checked += CustomCheckbox_OnChecked;
            _mainWindow.CustomCheckbox.IsEnabledChanged += CustomCheckbox_OnIsEnabledChanged;
            _mainWindow.CustomCheckbox.Unchecked += CustomCheckbox_OnUnchecked;
        }

        private void CustomCheckbox_OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_mainWindow.CustomCheckbox == null) return;
            
            if (_mainWindow.CustomCheckbox.IsChecked == true)
            {
                _mainWindow.customFilter.IsEnabled = true;
            }
            else
                _mainWindow.customFilter.IsEnabled = false;
        }

        private void CustomCheckbox_OnChecked(object sender, RoutedEventArgs e)
        {
            if (_mainWindow.CustomCheckbox == null) return;
            _mainWindow.customFilter.IsEnabled = true;

            _mainWindow.presetsBox.IsEnabled = false;
            _mainWindow.ipTextbox.IsEnabled = false;
            _mainWindow.portTextbox.IsEnabled = false;

            _mainWindow.ipTextbox.Text = "";
            _mainWindow.portTextbox.Text = "";
        }

        private void CustomCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (_mainWindow.CustomCheckbox == null) return;
            _mainWindow.customFilter.IsEnabled = false;

            _mainWindow.presetsBox.IsEnabled = true;
            _mainWindow.ipTextbox.IsEnabled = true;
            _mainWindow.portTextbox.IsEnabled = true;
        }
    }
}