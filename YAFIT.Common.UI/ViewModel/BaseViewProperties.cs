using System.ComponentModel;
using System.Diagnostics;

namespace YAFIT.Common.UI.ViewModel
{
    /// <summary>
    /// Eine Basisklasse für alle ViewProperties
    /// </summary>
    public class BaseViewProperties : INotifyPropertyChanged
    {
        #region events
        /// <summary>
        /// Ein Event, das ausgelöst wird, wenn sich eine Property ändert
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;


        #endregion

        #region properties
        /// <summary>
        /// Eine Methode um im View zu triggern das sich die Property geändert hat
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        public virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Eine Methode um im View die Property zusetzen / übergeben / updaten
        /// </summary>
        /// <typeparam name="T">Datentyp</typeparam>
        /// <param name="propertyName">Property Namen</param>
        /// <param name="backingField">Variable</param>
        /// <param name="value">Neuer Wert</param>
        /// <returns>Gibt true an wenn die Property geändert werden konnte, sonst false</returns>
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

        /// <summary>
        /// Eine Methode zur verifizerung und Meldung von Properties die nicht gefunden werden
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <exception cref="ArgumentException">Wirft ein ArgumentException, wenn die Property nicht gefunden werden konnte.</exception>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentException("BaseViewProperties.VerifyPropertyName Property not found", propertyName);
            }
        }

        #endregion
    }
}
