using MyPlathsRecordingSoftware.Commands;
using MyPlathsRecordingSoftware.Dialog;
using MyPlathsRecordingSoftware.Random;
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
       
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
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

      
    }
}
