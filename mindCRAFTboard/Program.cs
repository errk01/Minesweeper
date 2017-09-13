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
					return " o ";
				}
			}
		}

	}
	class Grid
	{

		public int length { set; get; }
		public static Random rnd = new Random();
		private Cell [,] Grid1;

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
					if (rnd.Next(0, 100) <= 15)
					{
						Grid1[i, j].isLive = true;
					}

					Console.Write(Grid1[i, j].ToString());

				}
				Console.WriteLine();
			}
		}

		//checking if cell is valid to count for when we check neighbors
		private bool isValid(int r, int c)
		{
			if (r >= 0 && r < length && c < length)
			{
				return true;
			}
			return false;
		}
		//counts number of neighbors with bombs
		private int checkNeighbor(int r, int c)
		{
			int mineCount = 0;


			for (int i = 0; i < 9; i++)
			{
				if (isValid(r, c) && Grid1[r, c].isLive)
				{
					mineCount++;
				}
				else
				{
					continue;
				}
			}
			return mineCount;


		}
	class Program
	{
		static void Main(string[] args)
		{
			Grid g = new Grid(5);
			Cell c = new Cell();
			Console.ReadKey();
		}
		
	}
}
       
 
	

