using Microsoft.AspNetCore.SignalR;

using Shared;

using System.Threading.Tasks;

namespace Server.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("RecvMessage", message);
        }
    }
}