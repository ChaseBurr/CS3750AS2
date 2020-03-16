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
        private static Dictionary<string, int[]> colorMap = new Dictionary<string, int[]>();

        // cell array
        private static List<Cell> cells = new List<Cell>();

        public async Task SendNewCells(int x, int y)
        {
            // check to see if cell exisits

            // syncs new tile with all users
            Cell cell = new Cell();
            cell.x = x;
            cell.y = y;
            cell.setColor(colorMap[Context.ConnectionId]);
            if ((cells.RemoveAll(innerCell => (innerCell.x == x && innerCell.y == y))) == 0) {
                cells.Add(cell);
            }
            await Clients.All.SendAsync("UpdateCells", cells);
        }

        public override async Task OnConnectedAsync()
        {
            // Assign colors for each user
            lock (colorMap)
            {
                // currently does not check if color is in use
                Random random = new Random();
                colorMap.Add(Context.ConnectionId, new[] { random.Next(0, 255), random.Next(0, 255), random.Next(0, 255) });
            }
            await Clients.All.SendAsync("UpdateCells", cells);
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            // remove users when they disconnect
            lock (colorMap)
            {
                colorMap.Remove(Context.ConnectionId);
            }
            return base.OnDisconnectedAsync(exception);
        }

        public void ChangeInterval(int interval)
        {
            // changes the update frequency
            Console.WriteLine(interval);
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

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            } else
            {
                Cell cell = (Cell)obj;
                return (x == cell.x) && (y == cell.y);
            }
        }
    }

}