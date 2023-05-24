using System;
using Microsoft.UI.Xaml.Controls;

namespace ERP.Components
{
    public sealed partial class ResultCount : UserControl
    {
        // Declare default values
        private const string DEFAULT_ICON = "ContactInfo";
        private string _icon = DEFAULT_ICON;

        // Initialise the component with the default values
        public ResultCount()
        {
            InitializeComponent();
            Glyph = GetGlyphValue(_icon);
        }

        // Function to generate Glyph value of the Icon
        private string GetGlyphValue(string icon)
        {
            Symbol symbol = (Symbol)Enum.Parse(typeof(Symbol), icon);
            return ((char)symbol).ToString();
        }

        // Declare all the variable parameters
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
    }
}
