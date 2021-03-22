using MyPlathsRecordingSoftware.Dialog;
using MyPlathsRecordingSoftware.Resolution;
using MyPlathsRecordingSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace MyPlathsRecordingSoftware.Views
{
    /// <summary>
    /// Interaction logic for RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window, IDialog
    {
        public RecordWindow()
        {
            InitializeComponent();
            DataContext = new RecordWindowModel();
            

        }

        
    }
}
