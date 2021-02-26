using MyPlathsRecordingSoftware.Views;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Default_WPF_MVVM_Pattern_Implemented
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //coordinates.Content = PointToScreen(pointToWindow);
            var relativePosition = e.GetPosition(this);
            var point = PointToScreen(relativePosition);
        }

    }
}
