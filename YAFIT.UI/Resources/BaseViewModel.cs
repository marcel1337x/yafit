using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace YAFIT.UI.Resources
{
    public abstract class BaseViewModel : BaseViewProperties, IDisposable
    {

        #region commands
        public ICommand? OnClose { get { return GetCommand("OnClose"); } }
        public ICommand? OnCancel { get { return GetCommand("OnCancel"); } }


        #endregion

        #region properties

        public Window? LinkedWindow
        {
            get
            {
                return _view;
            }
            set
            {
                if (_view != null)
                {
                    _view.Closing -= ClosingView;
                }

                _view = value;
                if (_view != null)
                {
                    _view.DataContext = this;
                    _view.Closing += ClosingView;
                    _view.ContentRendered += WindowRendered;
                }
                LinkedWindowChanged();
            }
        }

        #endregion

        public string WindowCaption { get; protected set; } = string.Empty;

        public bool CanCloseView { get; set; } = true;

        public BaseViewModel(Window window)
        {
            _view = window;
            AddCommand("OnClose", new RelayCommand(CloseView, CanClose));
            AddCommand("OnCancel", new RelayCommand(CancelView));
        }
        public virtual void Dispose()
        {

        }

        protected void SetBusy(bool state = true)
        {
            _isViewModelBusy = state;
            Mouse.OverrideCursor = _isViewModelBusy ? Cursors.Wait : null;
        }

        protected virtual void CloseView()
        {
            LinkedWindow?.Close();
        }

        protected virtual void CancelView()
        {
            if (LinkedWindow != null)
            {
                LinkedWindow.DialogResult = null;
                LinkedWindow.Close();
            }
        }

        protected void ShowChildView(Window view, BaseViewModel viewModel, bool showInTaskbar = false)
        {
            view.Owner = LinkedWindow ?? Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            viewModel.LinkedWindow = view;
            view.ShowInTaskbar = showInTaskbar;
            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            view.ShowDialog();
        }

        protected void RefreshCommands()
        {
            foreach (var command in _commands4Refresh.Values)
            {
                command.RaisCanExecuteChanged();
            }
        }
        protected void AddCommand(string commandName, RelayCommand command)
        {
            _commands4Refresh.Add(commandName, command);
        }

        protected ICommand? GetCommand(string commandName)
        {
            foreach (var command in _commands4Refresh)
            {
                if (command.Key == commandName)
                {
                    return command.Value;
                }
            }
            return null;
        }

        protected virtual void LinkedWindowChanged()
        {

        }
        protected virtual void ViewRendered()
        {

        }

        private void ClosingView(object? sender, CancelEventArgs e)
        {
            if (CanCloseView == false)
            {
                e.Cancel = true;
            }
        }

        private void WindowRendered(object? sender, EventArgs e)
        {
            ViewRendered();
        }

        private bool CanClose()
        {
            if (LinkedWindow != null)
            {
                return CanCloseView;
            }
            return false;
        }


        protected Window? _view = null;
        private Dictionary<string, RelayCommand> _commands4Refresh = [];
        private bool _isViewModelBusy = false;
    }
}
