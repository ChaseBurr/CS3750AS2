using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRGame.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendNewTiles(int x, int y, int r, int g, int b)
        {
            await Clients.All.SendAsync("AddTile", 1, 1, 255, 255, 255);
        }

        public static void main()
        {

        }
    }
}