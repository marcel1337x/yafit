using System.ComponentModel;
using System.Diagnostics;

namespace YAFIT.Common.UI.ViewModel
{
    public class BaseViewProperties : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentException("BaseViewProperties.VerifyPropertyName Property not found", propertyName);
            }
        }
    }
}
