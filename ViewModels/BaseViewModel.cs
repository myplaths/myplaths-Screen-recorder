using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlathsRecordingSoftware.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
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
    }
}
