using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Of_Life.Classes
{
    public class Logic
    {
        // private bool StartStop = false;

        private List<Cells> cells;
        private Cells[,] CurrentGeneration = new Cells[20, 20];
        private Cells[,] NextGeneration = new Cells[20, 20];

        // Visualization
        // { 0 c 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { a x a 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { 0 c 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 1 1 1 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 }


        // { 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0 0 0 0 0 0 },
        // { 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0 0 0 0 0 0 },

        public Logic(List<Cells> cells)
        {
            this.cells = cells;
            foreach(Cells cell in cells)
            {
                CurrentGeneration[cell.x, cell.y] = cell;
            }
        }

        private void doogic()
        {
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    if (CurrentGeneration[i, j] != null)
                    {
                        // Check upper and lower
                        if (CurrentGeneration[i - 1, j] != null && CurrentGeneration[i + 1, j] != null)
                        {
                            NextGeneration[i, j + 1] = new Cells(i, j);
                            // NextGeneration[i, j + 1].setColor();
                            // NextGeneration[i, j - 1] = 1;
                        } else
                        {
                            /*NextGeneration[i, j] = 0;
                            NextGeneration[i, j] = 0;*/
                        }

                        /*// Check Sides
                        if (CurrentGeneration[i, j - 1] == 1 && CurrentGeneration[i, j + 1] == 1)
                        {
                            NextGeneration[i, j + 1] = 1;
                            NextGeneration[i, j - 1] = 1;
                        } else
                        {
                            NextGeneration[i, j] = 0;
                            NextGeneration[i, j] = 0;
                        }*/
                    }
                }
            }
        }

        public List<Cells> getList()
        {
            // logic to return list of cells
            

            return cells;
        }
    }
}
