using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YAFIT.UI.Resources
{
    public abstract class BaseViewProperties : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string caller = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        protected bool SetProperty<T>(string propertyName, ref T backingField, T value)
        {
            bool hasChanged = true;
            if (backingField == null && value != null)
            {
                hasChanged = false;
            }
            else if ((value == null && backingField == null) || backingField?.Equals(value) == true)
            {

                hasChanged = false;
            }

            if (hasChanged == true)
            {
                backingField = value;
                OnPropertyChanged(propertyName);
            }
            return hasChanged;
        }

    }
}
