using System;
using Microsoft.UI.Xaml.Controls;

namespace ERP.Components
{
    public sealed partial class CompactButton : UserControl
    {
        // Declare default values
        private const string DEFAULT_LABEL = "Button";
        private const string DEFAULT_ICON = "Add";
        private string _icon = DEFAULT_ICON;

        // Initialise the component with the default values
        public CompactButton()
        {
            InitializeComponent();
            Label = DEFAULT_LABEL;
            Glyph = GetGlyphValue(_icon);
            FontSize = "12";
            IconSize = "13";
        }

        // Function to generate Glyph value of the passed Icon name
        private string GetGlyphValue(string icon)
        {
            Symbol symbol = (Symbol)Enum.Parse(typeof(Symbol), icon);
            return ((char)symbol).ToString();
        }

        // Declare all the variable parameters
        public string Label { get; set; }
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                Glyph = GetGlyphValue(_icon);
            }
        }
        public string Glyph { get; private set; }
        public new string FontSize { get; set; }
        public string IconSize { get; set; }
    }
}
