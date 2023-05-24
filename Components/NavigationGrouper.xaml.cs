using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace ERP.Components
{
    public sealed partial class NavigationGrouper : UserControl
    {
        // Declare default values
        private const string DEFAULT_LABEL = "";

        // Initialise the component with the default values
        public NavigationGrouper()
        {
            InitializeComponent();
            DataContext = this;
            Label = DEFAULT_LABEL;
        }

        // Function to fetch the contents of the ContentProperty tag
        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(NavigationGrouper), new PropertyMetadata(null));

        // Declare all the variable parameters
        public new object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public string Label { get; set; }
    }
}
