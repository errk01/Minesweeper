/*
 *Erik Taylor
 *CST-227
 *9/10/17
  */



using mindCRAFTboard;
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

	class Cell
		{
			public static Random rnd = new Random();

			public bool isLive { set; get; }
			public int liveNeighbors { set; get; }
			public bool visited { set; get; }
			public int row { set; get; }
			public int col { set; get; }
        public bool isVisited { get; internal set; }

        public Cell()
			{
				isLive = false;
				liveNeighbors = 0;
				visited = false;
				row = -1;
				col = -1;
			}

			public override string ToString()
			{
				if (isLive)
				{
					return " * ";
				}
				else
				{
					return " " + this.liveNeighbors + " ";
				}
			}
		}

	}

class Program
{
    static void Main(string[] args)
    {
        GameBoard g = new GameBoard(10);   
        g.playGame();
        Console.ReadKey();


    }




	}
       
 
	

