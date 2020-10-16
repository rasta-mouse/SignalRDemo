using Microsoft.AspNetCore.SignalR.Client;

using Shared;

using System;
using System.Threading.Tasks;

namespace Client.Services
{
    public class SignalRService
    {
        private readonly HubConnection Connection;
        public event Action<Message> MessageReceived;

        public SignalRService(HubConnection connection)
        {
            Connection = connection;
            Connection.On<Message>("RecvMessage", (msg) => MessageReceived?.Invoke(msg));

            Connect().ContinueWith((task) => { });
        }

        public async Task Connect()
        {
            await Connection.StartAsync();
        }

        public async Task SendMessage(Message message)
        {
            await Connection.SendAsync("SendMessage", message);
        }
    }
}