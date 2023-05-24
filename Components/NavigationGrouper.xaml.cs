// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

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
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ERP.Components
{
    public sealed partial class NavigationGrouper : UserControl
    {
        private const string DEFAULT_LABEL = "";

        public new object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static new readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(NavigationGrouper), new PropertyMetadata(null));

        public NavigationGrouper()
        {
            this.InitializeComponent();
            this.DataContext = this;
            Label = DEFAULT_LABEL;
        }

        public string Label { get; set; }
    }
}
