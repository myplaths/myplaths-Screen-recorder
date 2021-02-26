using Default_WPF_MVVM_Pattern_Implemented.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Default_WPF_MVVM_Pattern_Implemented
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            MainWindowModel mainWindowModel = new MainWindowModel();
            mainWindow.DataContext = mainWindowModel;
            mainWindow.Show();
        }
    }
}
