using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Of_Life.Classes
{
    public class Logic
    {
        private bool StartStop = false;

        private int[,] CurrentGeneration = new int[20,20];
        private int[,] NextGeneration = new int[20, 20];

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

        public void dologic()
        {
            for (int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    if(CurrentGeneration[i,j] == 1)
                    {
                        // Check upper and lower
                        if(CurrentGeneration[i - 1, j] == 1 && CurrentGeneration[i+1, j] == 1)
                        {
                            NextGeneration[i, j+1] = 1;
                            NextGeneration[i, j-1] = 1;
                        }

                        // Check Sides
                        if (CurrentGeneration[i, j-1] == 1 && CurrentGeneration[i, j + 1] == 1)
                        {
                            NextGeneration[i, j + 1] = 1;
                            NextGeneration[i, j - 1] = 1;
                        }
                    }
                }
            }
        }

    }
}
