using Client.Commands;
using Client.Views;

using System.Windows.Input;

namespace Client.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public LoginView View;

        public string Username { get; set; }
        public ICommand LoginCommand { get; }

        public LoginViewModel(LoginView view)
        {
            View = view;

            LoginCommand = new LoginCommand(this);
        }
    }
}