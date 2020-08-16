using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrismDemo.Dialogs.Dialogs
{
    /// <summary>
    /// Interaction logic for MyCustomWindow.xaml
    /// </summary>
    public partial class MyCustomWindow : Window, IDialogWindow
    {
        public MyCustomWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
