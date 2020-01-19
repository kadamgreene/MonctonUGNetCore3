using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonctonUG.BlazorServer.Data
{
    public class SessionState : INotifyPropertyChanged
    {
        private int _currentCount;
        public int CurrentCount { get => _currentCount; set => SetProperty(ref _currentCount, value); }

        private void SetProperty<T>(ref T prop, T value, [CallerMemberName] string propertyName = null)
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
