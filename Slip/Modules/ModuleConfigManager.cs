using System;
using System.Collections.Generic;

namespace Slip.Modules
{
    internal class ModuleConfigManager : IModuleConfigManager
    {
        private MainWindow _mainWindow;

        public ModuleConfigManager(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public List<Config> GetModulesConfig()
        {
            List<Config> configList = new List<Config>();

            Config? lagConfig = GetLagConfig();
            if (lagConfig != null) configList.Add((Config) lagConfig);

            Config? dropConfig = GetDropConfig();
            if (dropConfig != null) configList.Add((Config)dropConfig);

            Config? throttleConfig = GetThrottleConfig();
            if (throttleConfig != null) configList.Add((Config)throttleConfig);

            Config? encryptConfig = GetEncryptConfig();
            if (encryptConfig != null) configList.Add((Config)encryptConfig);

            Config? shuffleConfig = GetShuffleConfig();
            if (shuffleConfig != null) configList.Add((Config)shuffleConfig);
            
            Config? duplicateConfig = GetDuplicateConfig();
            if (duplicateConfig != null) configList.Add((Config)duplicateConfig);

            Config? trafficShaperConfig = GetTrafficShaperConfig();
            if (trafficShaperConfig != null) configList.Add((Config)trafficShaperConfig);

            return configList;
        }

        private Config? GetLagConfig()
        {
            return GetConfig(_mainWindow.lagToggle.IsChecked.Value,
                _mainWindow.lagInbound.IsChecked.Value,
                _mainWindow.lagOutbound.IsChecked.Value,
                0,
                (float) _mainWindow.lagSlider.Value,
                0,
                false,
                SimulationType.Lag);
        }

        private Config? GetDropConfig()
        {
            return GetConfig(_mainWindow.dropToggle.IsChecked.Value,
                _mainWindow.dropInbound.IsChecked.Value,
                _mainWindow.dropOutbound.IsChecked.Value,
                (float) _mainWindow.dropChanceSlider.Value,
                0,
                0,
                false,
                SimulationType.Drop);
        }

        private Config? GetThrottleConfig()
        {
            return GetConfig(_mainWindow.throttleToggle.IsChecked.Value,
                _mainWindow.throttleInbound.IsChecked.Value,
                _mainWindow.throttleOutbound.IsChecked.Value,
                (float) _mainWindow.throttleChanceSlider.Value,
                (float)Convert.ToDouble(_mainWindow.delayTextbox.Text), 
                0,
                _mainWindow.throttleDropCheckbox.IsChecked.Value,
                SimulationType.Throttle);
        }

        private Config? GetEncryptConfig()
        {
            return GetConfig(_mainWindow.encryptToggle.IsChecked.Value,
                _mainWindow.encryptInbound.IsChecked.Value,
                _mainWindow.encryptOutbound.IsChecked.Value,
                (float) _mainWindow.encryptChanceSlider.Value,
                0,
                0,
                false,
                SimulationType.Encrypt);
        }

        private Config? GetShuffleConfig()
        {
            return GetConfig(_mainWindow.shuffleToggle.IsChecked.Value,
                _mainWindow.shuffleInbound.IsChecked.Value,
                _mainWindow.shuffleOutbound.IsChecked.Value,
                (float) _mainWindow.shuffleChanceSlider.Value,
                0,
                (int) _mainWindow.minPackets.Value,
                false,
                SimulationType.Shuffle);
        }

        private Config? GetDuplicateConfig()
        {
            return GetConfig(_mainWindow.duplicateToggle.IsChecked.Value,
                _mainWindow.duplicateInbound.IsChecked.Value,
                _mainWindow.duplicateOutbound.IsChecked.Value,
                (float) _mainWindow.duplicateChanceSlider.Value,
                0,
                (int) _mainWindow.numCopies.Value,
                false,
                SimulationType.Duplicate);
        }

        private Config? GetTrafficShaperConfig()
        {
            return GetConfig(_mainWindow.trafficShaperToggle.IsChecked.Value,
                _mainWindow.trafficShaperInbound.IsChecked.Value,
                _mainWindow.trafficShaperOutbound.IsChecked.Value,
                (float) _mainWindow.trafficShaperChanceSlider.Value,
                0,
                Convert.ToInt32(_mainWindow.speedLimitTextbox.Text),
                false,
                SimulationType.TrafficShaper);
        }

        private Config? GetConfig(bool enabled, bool inbound, bool outbound, float chance,
            float delay, int num, bool drop, SimulationType simulationType)
        {
            if (!enabled) return null;
            return SetConfig(enabled, inbound, outbound, chance, delay, num, drop, simulationType);
        }

        private Config SetConfig(bool enabled, bool inbound, bool outbound, float chance,
            float delay, int num, bool drop, SimulationType simulationType)
        {
            Config config = new Config();
            config.enabled = enabled;
            config.inbound = inbound;
            config.outbound = outbound;
            config.chance = chance;
            config.delay = delay;
            config.num = num;
            config.drop = drop;
            config.simulationType = simulationType;
            return config;
        }

        internal string GetFilter()
        {
            string filter = null;

            if (_mainWindow.presetsBox.SelectedIndex == 0)
                filter = "true";
            else if (_mainWindow.presetsBox.SelectedIndex == 1)
                filter = "inbound";
            else if (_mainWindow.presetsBox.SelectedIndex == 2)
                filter = "outbound";
            else if (_mainWindow.presetsBox.SelectedIndex == 3)
                filter = "loopback";
            else if (_mainWindow.presetsBox.SelectedIndex == 4)
                filter = "ip.DstAddr == " + _mainWindow.ipTextbox.Text;
            else if (_mainWindow.presetsBox.SelectedIndex == 5)
                filter = "ip.DstPort == " + _mainWindow.portTextbox.Text;
            else if (_mainWindow.presetsBox.SelectedIndex == 6)
                filter = "ip.DstAddr == " + _mainWindow.ipTextbox.Text + " and ip.DstPort == " + _mainWindow.portTextbox.Text;
            return filter;
        }
    }
}