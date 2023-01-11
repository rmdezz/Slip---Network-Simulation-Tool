using System.IO;
using Slip.EventHandlers;
using Slip.Modules;
using Slip.Simulation;
using Slip.Theming;

namespace Slip
{
    public partial class MainWindow
    {
        private readonly ModuleConfigManager _moduleConfigManager;

        private UiEventHandlers UiEventHandlers { get; }
        internal ModuleConfigManager ModuleConfigManager => _moduleConfigManager;
        internal SimulationController SimulationController { get; }

        public MainWindow()
        {
            InitializeComponent();

            IThemeChanger themeChanger;
            
            themeChanger = new LightThemeChanger();
            themeChanger.ChangeTheme();
            
            IBackgroundChanger backgroundChanger = new BackgroundChanger(tabControl, "#ECECEC");
            backgroundChanger.ChangeBackground();

            // 255, 155, 0
            themeChanger = new CustomThemeChanger(165, 165, 165);
            themeChanger.ChangeTheme();
            
            WinDivert.SetDllDirectory(Directory.GetCurrentDirectory()); // output directory
            
            UiEventHandlers = new UiEventHandlers(this);
            _moduleConfigManager = new ModuleConfigManager(this);
            SimulationController = new SimulationController(_moduleConfigManager, this);
        }
    }
}
