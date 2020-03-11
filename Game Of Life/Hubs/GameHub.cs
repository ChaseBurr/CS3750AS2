using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRGame.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendNewTiles(int x, int y, int r, int g, int b)
        {
            // syncs new tile with all users
            await Clients.All.SendAsync("AddTile", x, y, r, g, b);
        }

        // TODO:
        // Add logic
        // Change colors for each user

    }
}