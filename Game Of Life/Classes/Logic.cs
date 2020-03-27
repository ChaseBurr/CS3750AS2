using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Of_Life.Classes
{
    public class Logic
    {
        // private bool StartStop = false;

        private Cells[,] CurrentGeneration = new Cells[22, 22];
        private Cells[,] NextGeneration = new Cells[22, 22];

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
            foreach(Cells cell in cells)
            {
                CurrentGeneration[cell.x + 1, cell.y + 1] = cell;
            }
        }

        private void doogic()
        {
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    List<Cells> neighbors = new List<Cells>();
                    for(int k = -1; k < 2; k++)
                    {
                        for(int l = -1; l < 2; l++)
                        {
                            if(k != 0 && l != 0)
                            {
                                if (CurrentGeneration[i + k, j + l] != null) neighbors.Add(CurrentGeneration[i + k, j + l]);
                            }
                        }
                    }
                    if(neighbors.Count > 2)
                    {
                        int red = 0;
                        int green = 0;
                        int blue = 0;
                        foreach(Cells cell in neighbors)
                        {
                            red += cell.red;
                            green += cell.green;
                            blue += cell.blue;
                        }
                        NextGeneration[i, j] = new Cells(i, j);
                        NextGeneration[i, j].setColor(new int[] { red, green, blue });
                    }
                    /*if (CurrentGeneration[i, j] != null)
                    {
                        // Check upper and lower
                        if (CurrentGeneration[i - 1, j] != null && CurrentGeneration[i + 1, j] != null)
                        {
                            NextGeneration[i, j + 1] = new Cells(i, j);
                            // NextGeneration[i, j + 1].setColor();
                            // NextGeneration[i, j - 1] = 1;
                        } else
                        {
                            *//*NextGeneration[i, j] = 0;
                            NextGeneration[i, j] = 0;*//*
                        }

                        *//*// Check Sides
                        if (CurrentGeneration[i, j - 1] == 1 && CurrentGeneration[i, j + 1] == 1)
                        {
                            NextGeneration[i, j + 1] = 1;
                            NextGeneration[i, j - 1] = 1;
                        } else
                        {
                            NextGeneration[i, j] = 0;
                            NextGeneration[i, j] = 0;
                        }*//*
                    }*/
                }
            }
        }

        public List<Cells> getList()
        {
            List<Cells> cells = new List<Cells>();
            // logic to return list of cells
            for(int i = 0; i < NextGeneration.Length; i++)
            {
                for(int j = 0; j < NextGeneration.Length; j++)
                {
                    if(NextGeneration[i,j] != null)
                    {
                        cells.Add(NextGeneration[i, j]);
                    }
                }
            }
            return cells;
        }
    }
}
