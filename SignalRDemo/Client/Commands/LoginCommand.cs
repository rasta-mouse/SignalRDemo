using Client.Services;
using Client.ViewModels;
using Client.Views;

using Microsoft.AspNetCore.SignalR.Client;

using System;
using System.Windows.Input;

namespace Client.Commands
{
    class LoginCommand : ICommand
    {
        private readonly LoginViewModel LoginViewModel;

        public event EventHandler CanExecuteChanged;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/MessageHub")
                .Build();

            var signalRService = new SignalRService(connection);

            var mainView = new MainView
            {
                DataContext = new MainViewModel(LoginViewModel.Username, signalRService)
            };

            LoginViewModel.View.Close();
            mainView.Show();
        }
    }
}