using System.Diagnostics;
using System.Threading;

namespace Slip.EventHandlers
{
    internal class WindowEventHandlers
    {
        private UiEventHandlers _uiEventHandlers;
        private MainWindow _mainWindow;
        
        internal WindowEventHandlers(UiEventHandlers uiEventHandlers, MainWindow mainWindow)
        {
            _uiEventHandlers = uiEventHandlers;
            _mainWindow = mainWindow;
            
            InitWindowEventHandlers();
        }

        private void InitWindowEventHandlers()
        {
            _mainWindow.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_uiEventHandlers._buttonEventHandlers.Stopped)
            {
                _mainWindow.SimulationController.StopSimulation();
                Thread.Sleep(500);
            }
            
            Process[] processes = Process.GetProcessesByName("SlipClient");
            if (processes.Length > 0)
                processes[0].Kill();
                //processes[0].CloseMainWindow();
            //consoleProcess.Kill();
        }
    }
}