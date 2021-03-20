using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for FrmConsole.xaml
    /// </summary>
    public partial class FrmConsole : Window
    {
        private class ControlWriter : TextWriter
        {
            private TextBox textbox;
            public ControlWriter(TextBox textbox)
            {
                this.textbox = textbox;
            }

            public override void WriteLine(char value)
            {
                textbox.Dispatcher.Invoke(new Action(() =>
                {
                    textbox.AppendText(value.ToString());
                    textbox.AppendText(Environment.NewLine);
                    textbox.ScrollToEnd();
                }));
            }

            public override void WriteLine(string value)
            {
                textbox.Dispatcher.Invoke(new Action(() =>
                {
                    textbox.AppendText(value);
                    textbox.AppendText(Environment.NewLine);
                    textbox.ScrollToEnd();
                }));
            }

            public override void Write(char value)
            {
                textbox.Dispatcher.Invoke(new Action(() =>
                {
                    textbox.AppendText(value.ToString());
                    textbox.ScrollToEnd();
                }));
            }

            public override void Write(string value)
            {
                textbox.Dispatcher.Invoke(new Action(() =>
                {
                    textbox.AppendText(value);
                    textbox.ScrollToEnd();
                }));
            }

            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }

            }
        }

        //DEFINICIONES DE LA CLASE
        #region DEFINICIONES DE LA CLASE

        #endregion


        //CONSTRUCTORES DE LA CLASE
        #region CONSTRUCTORES DE LA CLASE

        public FrmConsole(string titulo)
        {
            InitializeComponent();
            lblTitulo.Content = titulo;
            Clear();
            btnCerrar.Click += new RoutedEventHandler(BtnCerrar_Click);
            Console.SetOut(new ControlWriter(txtInner));
            DesactivarCerrar();
        }

        #endregion


        //PROPIEDADES
        #region PROPIEDADES

        #endregion


        //DELEGADOS
        #region DELEGADOS

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion


        //METODOS Y FUNCIONES
        #region METODOS Y FUNCIONES

        public void ActivarCerrar()
        {
            btnCerrar.IsEnabled = true;
        }

        public void Clear()
        {
            txtInner.Clear();
        }

        public void DesactivarCerrar()
        {
            btnCerrar.IsEnabled = false;
        }

        #endregion
    }
}
