using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace ERP.Components
{
    public sealed partial class SearchButton : UserControl
    {
        // Declare default values
        private const string DEFAULT_LABEL = "Button";

        // Initialise the component with the default values
        public SearchButton()
        {
            InitializeComponent();
            Label = DEFAULT_LABEL;
            FontSize = "13";
            IconSize = "25";
            Width = "NaN";
            Height = "70";
        }

        // Update animated button state when pointer click is initiated
        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            AnimatedIcon.SetState(this.searchAnimatedIcon, "PointerOver");
        }

        // Update animated button state when pointer click is ended
        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            AnimatedIcon.SetState(this.searchAnimatedIcon, "Normal");
        }

        // Declare all the variable parameters
        public string Label { get; set; }
        public new string FontSize { get; set; }
        public string IconSize { get; set; }
        public new string Width { get; set; }
        public new string Height { get; set; }
    }
}
