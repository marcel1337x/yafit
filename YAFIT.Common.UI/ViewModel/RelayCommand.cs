using System.Windows.Input;

namespace YAFIT.Common.UI.ViewModel
{
    /// <summary>
    /// Eine Klasse, die ein ICommand implementiert
    /// </summary>
    /// <param name="action2execute">Methoden die ausgeführt wird</param>
    /// <param name="canExecute">Funktion(Methode) die abfragt ob die Action ausgeführt werden darf</param>
    public class RelayCommand(Action action2execute, Func<bool>? canExecute = null) : ICommand
    {
        #region events
        /// <summary>
        /// Event, das ausgelöst wird, wenn sich die Ausführbarkeit des Befehls geändert hat
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        #endregion

        #region properties
        /// <summary>
        /// Gibt an, ob der Befehl ausgeführt werden kann
        /// </summary>
        public bool IsExecutable
        {
            get { return _isExecutable; }
            set
            {
                if (_isExecutable != value)
                {
                    _isExecutable = value;
                    RaisCanExecuteChanged();
                }
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Überprüft, ob der Befehl ausgeführt werden kann
        /// </summary>
        /// <param name="parameter">Parameter (wird nicht genutzt)</param>
        /// <returns>Gibt true an, wenn es ausführbar ist, sonst false</returns>
        public bool CanExecute(object? parameter)
        {
            if (_canExecuteAction != null)
            {
                IsExecutable = _canExecuteAction();
            }
            return IsExecutable;

        }

        /// <summary>
        /// Führt den Befehl aus
        /// </summary>
        /// <param name="parameter">Parameter (wird nicht genutzt)</param>
        public void Execute(object? parameter)
        {
            _action2execute();
        }

        /// <summary>
        /// Löst das CanExecuteChanged-Event aus ob der Befehl ausgeführt werden kann
        /// </summary>
        public void RaisCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        #endregion

        #region member variables

        private bool _isExecutable = true;
        private readonly Action _action2execute = action2execute;
        private readonly Func<bool>? _canExecuteAction = canExecute;

        #endregion
    }
}
