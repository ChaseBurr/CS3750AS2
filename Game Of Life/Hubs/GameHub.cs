using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SignalRGame.Hubs 
{
    public class GameHub : Hub 
    {
        public async Task SendNewTiles()
        {
            // syncs new tile with all users
            /*await Clients.All.SendAsync("AddTile", x, y, r, g, b);*/

            // test array
            Cell testCell = new Cell();
            testCell.x = 1;
            testCell.y = 1;
            testCell.red = 255;
            testCell.blue = 0;
            testCell.green = 255;
            Cell testCell1 = new Cell();
            testCell1.x = 1;
            testCell1.y = 1;
            testCell1.red = 125;
            testCell1.blue = 0;
            testCell1.green = 255;
            Cell[] cellArray = { testCell, testCell1 };
            await Clients.All.SendAsync("TestMethod", cellArray);
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

        [JsonProperty("blue")]
        public int blue { get; set; }

        [JsonProperty("green")]
        public int green { get; set; }

        // We don't want the client to get the "LastUpdatedBy" property
        [JsonIgnore]
        public string LastUpdatedBy { get; set; }
    }


    /*public class Tile
    {
        // unable to send via signalr it seems.....
        int x, y, red, green, blue;

        public Tile(int x, int y, int red, int green, int blue)
        {
            this.x = x;
            this.y = y;
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

    }*/

}