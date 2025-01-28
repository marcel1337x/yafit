using System.Windows.Input;

namespace YAFIT.Common.UI.ViewModel
{

    public class RelayCommand(Action action2execute, Func<bool>? canExecute = null) : ICommand
    {
        public event EventHandler? CanExecuteChanged;

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

        public bool CanExecute(object? parameter)
        {
            if (_canExecuteAction != null)
            {
                IsExecutable = _canExecuteAction();
            }
            return IsExecutable;

        }

        public void Execute(object? parameter)
        {
            _action2execute();
        }

        public void RaisCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        private bool _isExecutable = true;
        private readonly Action _action2execute = action2execute;
        private readonly Func<bool>? _canExecuteAction = canExecute;
    }
}
