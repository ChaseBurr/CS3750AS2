using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace SignalRGame.Hubs 
{
    public class GameHub : Hub
    {

        // color maping
        private static readonly Dictionary<string, int[]> colorMap = new Dictionary<string, int[]>();

        // cell array
        private static List<Cell> cells = new List<Cell>();

        public async Task SendNewCells(int x, int y)
        {
            // syncs new tile with all users
            Cell cell = new Cell();
            cell.x = x;
            cell.y = y;
            cell.setColor(colorMap[Context.ConnectionId]);
            cells.Add(cell);
            await Clients.All.SendAsync("UpdateCells", cells);
        }

        // TODO:
        // Add logic
        // Change colors for each user
        public override async Task OnConnectedAsync()
        {
            lock (colorMap)
            {
                Random random = new Random();
                colorMap.Add(Context.ConnectionId, new[] { random.Next(0, 255), random.Next(0, 255), random.Next(0, 255) });
            }
            await Clients.All.SendAsync("UpdateCells", cells);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            lock (colorMap)
            {
                colorMap.Remove(Context.ConnectionId);
            }
            return base.OnDisconnectedAsync(exception);
        }

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

        public void setColor(int[] color)
        {
            this.red = color[0];
            this.green = color[1];
            this.blue = color[2];
        }
    }

}