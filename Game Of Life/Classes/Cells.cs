using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Of_Life.Classes
{
    public class Cells
    {
        public int y { get;}
        public int x { get;}
        public string color { get; set; }
        public Cells(int x, int y, string color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}
