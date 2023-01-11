namespace Slip.EventHandlers
{
    internal class UiEventHandlers
    {
        private MainWindow _mainWindow;
        private readonly LabelEventHandlers _labelEventHandlers;
        private readonly ComboboxEventHandlers _comboboxEventHandlers;
        private readonly CheckboxEventHandlers _checkboxEventHandlers;
        internal readonly ButtonEventHandlers _buttonEventHandlers;
        private readonly SliderEventHandlers _sliderEventHandlers;
        private readonly WindowEventHandlers _windowEventHandlers;

        public UiEventHandlers(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            _sliderEventHandlers = new SliderEventHandlers(mainWindow);
            _labelEventHandlers = new LabelEventHandlers(mainWindow);
            _comboboxEventHandlers = new ComboboxEventHandlers(mainWindow);
            _buttonEventHandlers = new ButtonEventHandlers(mainWindow);
            _checkboxEventHandlers = new CheckboxEventHandlers(this, mainWindow);
            _windowEventHandlers = new WindowEventHandlers(this, mainWindow);
        }
    }
}