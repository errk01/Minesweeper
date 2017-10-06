using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mindCRAFTboard
{
    class GameBoard : Grid, iPlayable
    {
        public GameBoard(int size) : base(size)
        {
        }

        

        public void playGame()
        {
            
            bool lose = false;
            bool win = false;
            int row, col;
            do
            {
                
                printGrid();
                Console.WriteLine();
                Console.WriteLine("Enter a row: ");
                row = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a col: ");
                col = int.Parse(Console.ReadLine());
                ProcessCell(Grid1[row, col]);
                Console.WriteLine("\n\n\n\n\n\n");
            }
            while (!lose && !win);
        }

        public bool ProcessCell(Cell c)
        {
            bool lose = false;
            if (c.isLive)
                lostGame(c.row, c.col);
            else if (c.isVisited)
                return lose;
            else if (Grid1[c.row, c.col].liveNeighbors == 0 && !Grid1[c.row, c.col].isLive)
            {
                DFS(c.row,c.col);
            }
            else
            {
                c.isVisited = true;
            }

            printGrid();
            return false;
        }


        public void lostGame(int r, int c)
        {
            if (Grid1[r, c].isLive)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("YOU LOST!!!");
                Console.WriteLine("Press Enter");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private ArrayList getNeighbors(int row, int col)
        {

            ArrayList list = new ArrayList();
            

            for (int curRow = row - 1; curRow <= row + 1; curRow++)
            {
                for (int curCol = col - 1; curCol <= col + 1; curCol++)
                {
                    if (curRow > 0 && curCol > 0 && curRow < length && curCol < length && Grid1[curRow, curCol].liveNeighbors == 0 && !Grid1[curRow, curCol].isLive)
                    {
                        list.Add(Grid1[curRow,curCol]);
                    }
                }

            }

            return list;
        }

        public void DFS(int row, int col) {

            
            if (Grid1[row, col].liveNeighbors == 0 && !Grid1[row, col].isLive && !Grid1[row, col].isVisited)
            {
                Grid1[row, col].isVisited = true;

                foreach (Cell cell in getNeighbors(row,col))
                {
                    DFS(cell.row, cell.col);
                }
            }

        }

        //prints grid during game
        public void printGrid()
        {
            int r = 0;
            int c = 0;

            while (r < length)
            {
                c = 0;
                while (c < length)
                {
                    if (!Grid1[r, c].isVisited)
                    {
                        Console.Write(" ? ");
                    }
                    else if (Grid1[r, c].liveNeighbors == 0 && !Grid1[r, c].isLive && Grid1[r,c].isVisited)
                    {

                        Console.Write(" ~ ");
                    }
                    else
                    {
                        Console.Write(" " + Grid1[r, c].liveNeighbors + " ");
                    }
                    c++;
                }
                Console.WriteLine("");
                r++;
            }
        }
        
        void iPlayable.playgame()
        {
            bool lost = false;

            while (!lost)
            {
                Console.WriteLine("enter row");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine("enter col");
                int col = int.Parse(Console.ReadLine());


            }

        }
    }
}