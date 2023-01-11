using System.Collections.Generic;
using System.Windows;
using Slip.Interfaces;
using Slip.Modules;

namespace Slip.Simulation
{
    public class StartSlip : IStartSimulation
    {
        private readonly IFileExistence fileExistence;
        private readonly IModuleConfigManager moduleConfigManager;
        private readonly IRunSlip runSlip;

        public StartSlip(IFileExistence fileExistence, IModuleConfigManager moduleConfigManager, IRunSlip runSlip)
        {
            this.fileExistence = fileExistence;
            this.moduleConfigManager = moduleConfigManager;
            this.runSlip = runSlip;
        }

        public bool Start(string filter)
        {
            if (!fileExistence.CheckFileExistence())
            {
                MessageBox.Show("Slip.dll not found in the current directory.");
                return false;
            }

            List<Config> configList = moduleConfigManager.GetModulesConfig();
            Config[] configArray = configList.ToArray();
            
            runSlip.Run(filter, configArray);
            return true;
        }
    }
}