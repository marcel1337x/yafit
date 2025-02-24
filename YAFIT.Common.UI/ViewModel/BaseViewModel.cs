using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace YAFIT.Common.UI.ViewModel
{
    /// <summary>
    /// Eine Basisklasse für alle ViewModels
    /// </summary>
    public abstract class BaseViewModel : BaseViewProperties, IDisposable
    {

        #region commands
        /// <summary>
        /// Eine Eigenschaft, die den Befehl zum Schließen des Fensters enthält
        /// </summary>
        public ICommand? OnClose { get { return GetCommand("OnClose"); } }
        /// <summary>
        /// Eine Eigenschaft, die den Befehl zum Abbrechen des Fensters enthält
        /// </summary>
        public ICommand? OnCancel { get { return GetCommand("OnCancel"); } }


        #endregion

        #region properties

        /// <summary>
        /// Eine Eigenschaft, die das verknüpfte Fenster enthält
        /// </summary>
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

        /// <summary>
        /// Eine Eigenschaft, die den Fenstertitel enthält
        /// </summary>

        public string WindowCaption { get; protected set; } = string.Empty;
        /// <summary>
        /// Eine Eigenschaft, die angibt, ob das Fenster geschlossen werden kann
        /// </summary>
        public bool CanCloseView { get; set; } = true;


        #endregion

        #region constructor

        /// <summary>
        /// Ein Konstruktor, der das Fenster als Parameter erhält
        /// </summary>
        /// <param name="window"></param>
        public BaseViewModel(Window window)
        {
            _view = window;
            AddCommand("OnClose", new RelayCommand(CloseView, CanClose));
            AddCommand("OnCancel", new RelayCommand(CancelView));
        }


        #endregion

        #region public methods
        /// <summary>
        /// Die Dispose Methode in der alle Ressourcen freigegeben werden
        /// </summary>
        public virtual void Dispose()
        {

        }

        #endregion

        #region protected methods

        /// <summary>
        /// Eine Methode, die den Mauszeiger auf Warten setzt
        /// </summary>
        /// <param name="state">Status aktiv?</param>
        protected void SetBusy(bool state = true)
        {
            _isViewModelBusy = state;
            Mouse.OverrideCursor = _isViewModelBusy ? Cursors.Wait : null;
        }

        /// <summary>
        /// Eine Methode, die das Fenster schließt
        /// </summary>
        protected virtual void CloseView()
        {
            LinkedWindow?.Close();
        }

        /// <summary>
        /// Eine Methode, die das Fenster abbricht
        /// </summary>
        protected virtual void CancelView()
        {
            if (LinkedWindow != null)
            {
                LinkedWindow.DialogResult = null;
                LinkedWindow.Close();
            }
        }

        /// <summary>
        /// Eine Methode, die ein Fenster anzeigt welches am Hauptfenster verküpft ist
        /// </summary>
        /// <param name="view"></param>
        /// <param name="viewModel"></param>
        /// <param name="showInTaskbar"></param>

        protected void ShowChildView(Window view, BaseViewModel viewModel, bool showInTaskbar = false)
        {
            view.Owner = LinkedWindow ?? Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            viewModel.LinkedWindow = view;
            view.ShowInTaskbar = showInTaskbar;
            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            view.ShowDialog();
        }

        /// <summary>
        /// Aktualisiere alle Befehle
        /// </summary>
        protected void RefreshCommands()
        {
            foreach (var command in _commands4Refresh.Values)
            {
                command.RaisCanExecuteChanged();
            }
        }

        /// <summary>
        /// Füge einen Befehl hinzu
        /// </summary>
        /// <param name="commandName">Name des Kommandos</param>
        /// <param name="command">RelacCommand Klasse</param>
        protected void AddCommand(string commandName, RelayCommand command)
        {
            _commands4Refresh.Add(commandName, command);
        }

        /// <summary>
        /// Gibt einen Befehl zurück
        /// </summary>
        /// <param name="commandName">Name des Kommandos</param>
        /// <returns>Gibt ein Kommando zurück wenn dieser vorhanden ist, sonst NULL</returns>
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

        /// <summary>
        /// Eine Methode, die aufgerufen wird, wenn sich das verknüpfte Fenster ändert
        /// </summary>
        protected virtual void LinkedWindowChanged()
        {

        }

        /// <summary>
        /// Eine Methode, die aufgerufen wird, nachdem das Fenster gerendert wurde
        /// </summary>
        protected virtual void ViewRendered()
        {

        }

        #endregion

        #region private methods

        /// <summary>
        /// Eine Methode, die aufgerufen wird, wenn das Fenster geschlossen wird
        /// </summary>
        /// <param name="sender">Das Fenster</param>
        /// <param name="e">CancelEventArgs</param>
        private void ClosingView(object? sender, CancelEventArgs e)
        {
            if (CanCloseView == false)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Eine Methode, die aufgerufen wird, wenn das Fenster gerendert wurde
        /// </summary>
        /// <param name="sender">Das Fenster</param>
        /// <param name="e">EventArgs</param>

        private void WindowRendered(object? sender, EventArgs e)
        {
            ViewRendered();
        }

        /// <summary>
        /// Eine Methode, die prüft, ob das Fenster geschlossen werden kann
        /// </summary>
        /// <returns></returns>
        private bool CanClose()
        {
            if (LinkedWindow != null)
            {
                return CanCloseView;
            }
            return false;
        }

        #endregion

        #region member variables

        private Dictionary<string, RelayCommand> _commands4Refresh = [];
        private bool _isViewModelBusy = false;

        protected Window? _view = null;

        #endregion
    }
}
