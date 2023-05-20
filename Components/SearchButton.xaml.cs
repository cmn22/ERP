using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;


namespace ERP.Components
{
    public sealed partial class SearchButton : UserControl
    {
        private const string DEFAULT_LABEL = "Button";

        public SearchButton()
        {
            this.InitializeComponent();
            Label = DEFAULT_LABEL;
            FontSize = "13";
            IconSize = "25";
            Width = "NaN";
            Height = "70";
        }

        public string Label { get; set; }
        public new string FontSize { get; set; }
        public string IconSize { get; set; }
        public new string Width { get; set; }
        public new string Height { get; set; }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            AnimatedIcon.SetState(this.searchAnimatedIcon, "PointerOver");
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            AnimatedIcon.SetState(this.searchAnimatedIcon, "Normal");
        }
    }
}
