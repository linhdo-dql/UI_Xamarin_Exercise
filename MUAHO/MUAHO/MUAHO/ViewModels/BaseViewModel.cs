using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MUAHO.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

            protected bool SetProperty<T>( ref T property, T value,
                [CallerMemberName] string propertyName = "",
                Action onChanged = null )
            {
                if ( EqualityComparer<T>.Default.Equals(property, value) )
                    return false;

                property = value;
                onChanged?.Invoke();
                OnPropertyChanged(propertyName);
                return true;
            }

            private void OnPropertyChanged( [CallerMemberName] string propertyName = "" )
            {
                PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
            }
    }
}
