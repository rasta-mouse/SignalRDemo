using Client.Services;
using Client.ViewModels;

using Shared;

using System;
using System.Windows.Input;

namespace Client.Commands
{
    public class SendMessage : ICommand
    {
        private readonly MainViewModel MainViewModel;
        private readonly SignalRService SignalRService;

        public event EventHandler CanExecuteChanged;

        public SendMessage(MainViewModel mainViewModel, SignalRService signalRService)
        {
            MainViewModel = mainViewModel;
            SignalRService = signalRService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await SignalRService.SendMessage(new Message { User = MainViewModel.Username, Text = MainViewModel.TextToSend });
        }
    }
}