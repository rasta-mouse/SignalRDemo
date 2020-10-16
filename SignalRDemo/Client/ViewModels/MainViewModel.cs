using Client.Commands;
using Client.Services;

using Shared;

using System;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string Username { get; private set; }

        private string _messages;
        public string Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(Messages));
                TextToSend = "";
            }
        }

        private string _textToSend;
        public string TextToSend
        {
            get
            {
                return _textToSend;
            }
            set
            {
                _textToSend = value;
                OnPropertyChanged(nameof(TextToSend));
            }
        }

        public ICommand SendMessage { get; }

        public MainViewModel(string username, SignalRService signalR)
        {
            Username = username;

            SendMessage = new SendMessage(this, signalR);

            signalR.MessageReceived += SignalR_MessageReceived;
        }

        private void SignalR_MessageReceived(Message msg)
        {
            if (string.IsNullOrEmpty(Messages))
            {
                Messages += new string(string.Format("[{0}] {1}", msg.User, msg.Text));
            }
            else
            {
                Messages += new string(Environment.NewLine + string.Format("[{0}] {1}", msg.User, msg.Text));
            }
        }
    }
}