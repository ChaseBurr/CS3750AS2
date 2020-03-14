using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SignalRGame.Hubs 
{
    public class GameHub : Hub 
    {

        // cell array
        List<Cell> cells = new List<Cell>();

        public async Task SendNewTiles(int x, int y)
        {
            // syncs new tile with all users
            Cell cell = new Cell();
            cell.x = x;
            cell.y = y;
            cell.red = 125;
            cell.green = 0;
            cell.blue = 255;
            cells.Add(cell);
            await Clients.All.SendAsync("UpdateCells", cells);
        }

        // TODO:
        // Add logic
        // Change colors for each user

    }


    public class Cell
    {
        [JsonProperty("x")]
        public int x { get; set; }

        [JsonProperty("y")]
        public int y { get; set; }

        [JsonProperty("red")]
        public int red { get; set; }

        [JsonProperty("green")]
        public int green { get; set; }

        [JsonProperty("blue")]
        public int blue { get; set; }

        // We don't want the client to get the "LastUpdatedBy" property
        [JsonIgnore]
        public string LastUpdatedBy { get; set; }
    }

}