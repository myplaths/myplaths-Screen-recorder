using MyPlathsRecordingSoftware.Commands;
using MyPlathsRecordingSoftware.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyPlathsRecordingSoftware.ViewModels
{
    public class RecordWindowModel : BaseViewModel,IDialogRequestClose
    {
        private BaseViewModel _selectedViewModel;

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
        public string Message { get; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public RecordWindowModel()
        {
        }

        public RecordWindowModel(string message)
        {
            Message = message;
            OkCommand = new DelegateCommand(Submit);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private void Cancel()
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false));
        }

        private void Submit()
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

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

        
    }
}
