using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRGame.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public static void main()
        {

        }
    }
}