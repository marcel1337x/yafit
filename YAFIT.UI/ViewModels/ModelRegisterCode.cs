using System.Windows;
using System.Windows.Input;
using YAFIT.Common.Extensions;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;
using YAFIT.Databases.Services;

namespace YAFIT.UI.ViewModels
{
    public class ModelRegisterCode : BaseViewModel
    {

        public ICommand OnRegister { get; private set; }

        public string RegisterCode
        {
            get { return _registerCode; }
            set { SetProperty("RegisterCode", ref _registerCode, value); }
        }

        public bool IsSuccessful
        {
            get { return _successful; }
        }

        public ModelRegisterCode(Window window, ModelMain windowMainModel) : base(window)
        {
            OnRegister = new RelayCommand(DoRegister);
            _loginData = [windowMainModel.LoginUname, windowMainModel.SecurePassword?.ConvertToPlainText()??"Password"];
        }

        private void DoRegister()
        {
            if (string.IsNullOrEmpty(_registerCode) == true)
            {
                MessageBox.Show("Gebe einen registrierungscode ein!");
                return;
            }
            RegisterService registerService = RegisterEntity.GetRegisterService();

            RegisterEntity? register = registerService.GetEntity(x => x.Code == _registerCode);

            if (register == null)
            {
                MessageBox.Show("Der Registrierungscode ist falsch!");
                return;
            }

            UserService userService = UserEntity.GetUserService();
            UserEntity user = new UserEntity()
            {
                IsAdmin = false,
                Name = _loginData[0],
                Password = _loginData[1]
            };

            _successful = userService.Insert(user);

            registerService.Delete(register);
            CancelView();
        }

        private bool _successful = false;

        private string _registerCode = string.Empty;

        private string[] _loginData = { };
    }
}
