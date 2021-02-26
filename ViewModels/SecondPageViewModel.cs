using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default_WPF_MVVM_Pattern_Implemented.ViewModels
{
    public class SecondPageViewModel : BaseViewModel
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
    }
}
