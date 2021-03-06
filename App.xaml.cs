using MyPlathsRecordingSoftware.Dialog;
using MyPlathsRecordingSoftware.ViewModels;
using MyPlathsRecordingSoftware.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyPlathsRecordingSoftware
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IDialogService dialogService = new DialogService(MainWindow);

            dialogService.Register<RecordWindowModel, RecordWindow>();

            MainWindow mainWindow = new MainWindow();
            MainWindowModel mainWindowModel = new MainWindowModel(dialogService);
            mainWindow.DataContext = mainWindowModel;
            mainWindow.Show();
        }
    }
}
