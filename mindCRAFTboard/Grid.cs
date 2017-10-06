using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Erik Taylor
 CST-227
 this is my own work
 */

namespace mindCRAFTboard
{
    class Grid
    {

        public int length { set; get; }
        public static Random rnd = new Random();
        public Cell[,] Grid1;

        //size = num of rows (grid is square)
        public Grid(int size)
        {
            length = size;
            Grid1 = new Cell[size, size];

            //building cells on grid
            for (int i = 0; i < length; i++)
            {

                for (int j = 0; j < length; j++)
                {
                    Grid1[i, j] = new Cell();
                    Grid1[i, j].row = i;
                    Grid1[i, j].col = j;

                    //setting isLive
                    if (rnd.Next(0, 100) <= 10)
                    {
                        Grid1[i, j].isLive = true;
                    }                   
                    
                }

            }

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                {
                    Grid1[i, j].liveNeighbors = checkNeighbor(i, j);
                }
        }


        // show the table grid
        public void PrintGrid()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(Grid1[i, j].ToString());
                }
                Console.WriteLine();
            }
        }

        //counts number of neighbors with bombs
        private int checkNeighbor(int r, int c)
        {
            int mineCount = 0;

            if (Grid1[r, c].isLive)
                return 9;

            for (int i = r-1; i < r+2; i++)
            {
                for(int j = c-1; j < c+2; j++)
                {
                    try
                    {
                        if (this.Grid1[i, j].isLive) mineCount++;
                    }
                    catch { };
                }
            }
            return mineCount;
        }

        }
    }
