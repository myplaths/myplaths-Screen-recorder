using MyPlathsRecordingSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyPlathsRecordingSoftware.Views
{
    /// <summary>
    /// Interaction logic for DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        #endregion
        public DebugWindow()
        {
            InitializeComponent();
            DataContext = this;
            Messages = new ObservableCollection<string>();       

        }

        public void AddMessages(string message)
        {
            ObservableCollection<string> output = new ObservableCollection<string>();
            output.Add(message);
            Messages = new ObservableCollection<string>(output);

        }


        private ObservableCollection<string> _Message;

        public ObservableCollection<string> Messages { get; set; }





    }



    public static class DisplayMesssage
    {
        private static double _screenWidth = SystemParameters.PrimaryScreenWidth;
        private static double _screenHeight = SystemParameters.PrimaryScreenHeight;

        public static void Log(string message)
        {
           
            bool isWindowOpen = false;
            foreach(Window w in Application.Current.Windows)
            {
                if(w is DebugWindow)
                {
                    isWindowOpen = true;
                    w.Activate();
                }
            }
            if(!isWindowOpen)
            {
                DebugWindow window = new DebugWindow();
                window.AddMessages(message);
                window.Left = _screenWidth - window.Width;
                window.Top = 30;
                window.Show();
            }
        }

    }

}
