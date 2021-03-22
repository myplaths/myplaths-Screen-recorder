using MyPlathsRecordingSoftware.Commands;
using MyPlathsRecordingSoftware.Dialog;
using MyPlathsRecordingSoftware.Random;
using MyPlathsRecordingSoftware.Resolution;
using MyPlathsRecordingSoftware.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace MyPlathsRecordingSoftware.ViewModels
{
    public class RecordWindowModel : BaseViewModel, IDialogRequestClose,ICommand
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get
            {
                return _selectedViewModel;
            }
            set
            {
                _selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        private readonly double _screenWidth = SystemParameters.PrimaryScreenWidth;
        private readonly double _screenHeight = SystemParameters.PrimaryScreenHeight;
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
        public event EventHandler<ResolutionEventArgs> SubmitWidthAndHeightRequested;
        public event EventHandler CanExecuteChanged;

        public string Message { get; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        private double _width;

        public double Width
        {
            get { return _width; }
            set { _width = value; OnPropertyChanged(nameof(Width));}
        }

        private double _height;

        public double Height
        {
            get { return _height; }
            set { _height = value; OnPropertyChanged(nameof(Height)); }
        }



        public RecordWindowModel()
        {
        }
        public RecordWindowModel(string message)
        {
            Message = message;
            OkCommand = new DelegateCommand<object>(Execute);
            CancelCommand = new DelegateCommand(Cancel);
          
            
        }

        private void Cancel()
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false));
        }
        public void Submit()
        {
            
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            double width = (double)values[0];
            double height = (double)values[1];
            Width = width;
            Height = height;
            Submit();
        }

        //
        #region notinuse
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

        
        #endregion
    }
}
