using System.Windows;
using System.Windows.Controls;

namespace Slip.EventHandlers
{
    public class ComboboxEventHandlers
    {
        private MainWindow _mainWindow;

        public ComboboxEventHandlers(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitCheckboxEventHandlers();
        }

        private void InitCheckboxEventHandlers()
        {
            OnSelectionChanged(_mainWindow.presetsBox, PresetsBox_OnSelectionChanged);
        }

        void OnSelectionChanged(ComboBox comboBox, SelectionChangedEventHandler eventHandler)
        {
            comboBox.SelectionChanged += eventHandler;
        }

        private void PresetsBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_mainWindow.presetsBox == null || _mainWindow.ipLabel == null ||
                _mainWindow.ipTextbox == null || _mainWindow.portLabel == null ||
                _mainWindow.portTextbox == null)
                return;

            if (_mainWindow.presetsBox.SelectedIndex == 4) // Specific IP
            {
                _mainWindow.ipLabel.Visibility = Visibility.Visible;
                _mainWindow.ipTextbox.Visibility = Visibility.Visible;

                _mainWindow.portLabel.Visibility = Visibility.Collapsed;
                _mainWindow.portTextbox.Visibility = Visibility.Collapsed;
            }
            else if (_mainWindow.presetsBox.SelectedIndex == 5) // Specific port
            {
                _mainWindow.ipLabel.Visibility = Visibility.Collapsed;
                _mainWindow.ipTextbox.Visibility = Visibility.Collapsed;

                _mainWindow.portLabel.Visibility = Visibility.Visible;
                _mainWindow.portTextbox.Visibility = Visibility.Visible;
            }
            else if (_mainWindow.presetsBox.SelectedIndex == 6) // Specific IP and port
            {
                _mainWindow.ipLabel.Visibility = Visibility.Visible;
                _mainWindow.ipTextbox.Visibility = Visibility.Visible;
                _mainWindow.portLabel.Visibility = Visibility.Visible;
                _mainWindow.portTextbox.Visibility = Visibility.Visible;
            }
            else
            {
                _mainWindow.ipLabel.Visibility = Visibility.Hidden;
                _mainWindow.ipTextbox.Visibility = Visibility.Hidden;
                _mainWindow.portLabel.Visibility = Visibility.Hidden;
                _mainWindow.portTextbox.Visibility = Visibility.Hidden;

                _mainWindow.ipTextbox.Text = "";
                _mainWindow.portTextbox.Text = "";
            }
        }
    }
}