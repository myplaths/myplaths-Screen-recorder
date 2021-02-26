
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

namespace MyPlathsRecordingSoftware.Views
{
    /// <summary>
    /// Interaction logic for DependencyTest.xaml
    /// </summary>
    public partial class DependencyTest : UserControl
    {
        public DependencyTest()
        {
            InitializeComponent();
            DataContext = this;
            //DataContext = new DependencyPropertyModel();
            Secret = "Test";
        }



        public string Secret
        {
            get { return (string)GetValue(SecretProperty); }
            set { SetValue(SecretProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Secret.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecretProperty =
            DependencyProperty.Register("Secret", typeof(string), typeof(DependencyTest), new PropertyMetadata("default"));


    }
}
