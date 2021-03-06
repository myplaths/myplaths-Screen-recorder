using Accord.Video;
using MyPlathsRecordingSoftware.Commands;
using MyPlathsRecordingSoftware;
using MyPlathsRecordingSoftware.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using MyPlathsRecordingSoftware.Dialog;

namespace MyPlathsRecordingSoftware.ViewModels
{
    //https://social.msdn.microsoft.com/Forums/vstudio/en-US/b59975f9-3039-42af-b6b6-9c6d17079d24/binding-mouse-position-in-mvvm-is-it-possible?forum=wpf
    public class MainWindowModel : BaseViewModel
    {
        bool captured = false;
        public ICommand _leftButtonDownCommand;
        public ICommand _leftButtonUpCommand;
        public ICommand _previewMouseMove;
        public ICommand _leftMouseButtonUp;
        public ICommand RunCommand { get; set; }
        private IVideoSource _videoSource;
        public IVideoSource VideoSource
        {
            get { return _videoSource; }
            set { _videoSource = value; OnPropertyChanged(nameof(VideoSource)); }
        }
        public ICommand LeftClickDownCommand { get; set; }
        public ICommand LeftClickUpCommand { get; set; }
        private double _rectangleWidth;
        public double RectangleWidth
        {
            get { return _rectangleWidth; }
            set { _rectangleWidth = value; OnPropertyChanged(nameof(RectangleWidth)); }
        }
        private double _rectangleHeight;
        public double RectangleHeight
        {
            get { return _rectangleHeight; }
            set { _rectangleHeight = value; OnPropertyChanged(nameof(RectangleHeight)); }
        }
        private string _TestText;
        public string TestText
        {
            get { return _TestText; }
            set { _TestText = value; OnPropertyChanged(nameof(TestText)); }
        }
        private readonly IDialogService _dialogService;

        public MainWindowModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            LeftClickDownCommand = new DelegateCommand(LeftClickDown);
            LeftClickUpCommand = new DelegateCommand<object>(LeftClickUp);
            //RectangleWidth = MouseDownBehavior.SetMouseDownCommand((UIElement)LeftMouseButtonDown, _previewMouseMove);
            RectangleWidth = 300;
            RectangleHeight = 300;
            PanelX = 100;
            PanelY = 100;
            RectX = PanelX - 50.0;
            RectY = PanelY - 50.0;

        }
        private void LeftClickUp(object parameter)
        {
            Point mousePos = Mouse.GetPosition((IInputElement)parameter);
            RectangleHeight = GetMousePosition().Y;
            Console.WriteLine("secondtime");
        }

        bool isFirstTime = false;


        private void LeftClickDown()
        {
            var viewModel = new RecordWindowModel("hello");

            bool? result = _dialogService.ShowDialog(viewModel);
            if(result.HasValue)
            {
                if(result.Value)
                {
                    Console.WriteLine("result has value");
                }
                else
                {
                    Console.WriteLine("result do not have value");
                }
            }

           

          
        }


        private Dictionary<double, double> GetPosition()
        {
            Dictionary<double, double> startingPos = new Dictionary<double, double>();
            startingPos.Add(GetMousePosition().X, GetMousePosition().Y);
            return startingPos;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);
        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        public static Point GetMousePosition()
        {
            var w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
        public ICommand PreviewMouseMove
        {
            get
            {
                return _previewMouseMove ?? (_previewMouseMove = new RelayCommand(
                   x =>
                   {
                       if(captured)
                       {
                           RectX = PanelX - 50.0;
                           RectY = PanelY - 50.0;
                       }
                   }));
            }
        }
        public ICommand LeftMouseButtonUp
        {
            get
            {
                return _leftMouseButtonUp ?? (_leftMouseButtonUp = new RelayCommand(
                   x =>
                   {
                       captured = false;
                   }));
            }
        }
        public ICommand LeftMouseButtonDown
        {
            get
            {
                return _leftButtonDownCommand ?? (_leftButtonDownCommand = new RelayCommand(
                   x =>
                   {
                       captured = true;
                   }));
            }
        }
        private double _panelX;
        private double _panelY;
        private double _rectX;
        private double _rectY;
        public double RectX
        {
            get { return _rectX; }
            set
            {
                if(value.Equals(_rectX)) return;
                _rectX = value;
                OnPropertyChanged("RectX");
            }
        }
        public double RectY
        {
            get { return _rectY; }
            set
            {
                if(value.Equals(_rectY)) return;
                _rectY = value;
                OnPropertyChanged("RectY");
            }
        }
        public double PanelX
        {
            get { return _panelX; }
            set
            {
                if(value.Equals(_panelX)) return;
                _panelX = value;
                OnPropertyChanged("PanelX");
            }
        }
        public double PanelY
        {
            get { return _panelY; }
            set
            {
                if(value.Equals(_panelY)) return;
                _panelY = value;
                OnPropertyChanged("PanelY");
            }
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if(TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
    }

   

    
}
