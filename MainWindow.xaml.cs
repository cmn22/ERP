using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace ERP
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Select the first menu item by default
            appNavigation.SelectedItem = appNavigation.MenuItems[0];
            appNavigation.SelectionChanged += appNavigation_SelectionChanged;
        }

        //Function to call corresponding view based on the selection made via navigation bar
        private void appNavigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args?.SelectedItem is NavigationViewItem selectedItem)
            {
                string pageName = selectedItem.Tag.ToString();
                Type pageType = Type.GetType($"ERP.Views.{pageName}");
                contentFrame.Navigate(pageType);
            }
        }
    }
}
