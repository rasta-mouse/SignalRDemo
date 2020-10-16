using Client.Services;
using Client.ViewModels;
using Client.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows;

namespace Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var loginView = new LoginView();
            var loginViewModel = new LoginViewModel(loginView);
            loginView.DataContext = loginViewModel;

            loginView.Show();
        }
    }
}