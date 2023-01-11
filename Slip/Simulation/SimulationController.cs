using System.IO;
using System.Reflection;
using Slip.Interfaces;
using Slip.Modules;

namespace Slip.Simulation
{
    internal class SimulationController
    {
        private MainWindow _mainWindow;
        private readonly IStartSimulation _startSimulation;
        private readonly IStopSimulation _stopSimulation;

        internal SimulationController(IModuleConfigManager moduleConfigManager, MainWindow _mainWindow)
        {
            this._mainWindow = _mainWindow;

            IFileExistence fileExistence = new SlipDllExistence(Path.Combine
            (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Slip.dll"));
            
            IRunSlip slipRunner = new SlipRunner(_mainWindow.statusLabel);
            _startSimulation = new StartSlip(fileExistence, moduleConfigManager, slipRunner);
            _stopSimulation = new StopSlip(_mainWindow.startButton);
        }

        public bool StartSimulation(string filter, ref bool stopped)
        {
            if (!_startSimulation.Start(filter)) return false;
            
            _mainWindow.startButton.Content = "Stop";
            stopped = false;
            return true;

        }

        public bool StopSimulation()
        {
            return _stopSimulation.Stop();
        }
    }
}