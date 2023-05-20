using System;
using Microsoft.UI.Xaml.Controls;

namespace ERP.Components
{

    public sealed partial class ResultCount : UserControl
    {
        private const string DEFAULT_ICON = "ContactInfo";
        private string _icon = DEFAULT_ICON;

        public ResultCount()
        {
            this.InitializeComponent();
            Glyph = GetGlyphValue(_icon);
        }

        private string GetGlyphValue(string icon)
        {
            Symbol symbol = (Symbol)Enum.Parse(typeof(Symbol), icon);
            return ((char)symbol).ToString();
        }

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
