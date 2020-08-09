using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmOptimised
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Grid Length : ");
            int gridLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Grid Width : ");
            int gridWidth = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Number of Live");
            //int numLiveCell = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of Generations");
            int numGen = Convert.ToInt32(Console.ReadLine());
            //create a randomize grid
            Random rnd = new Random();
            int[,] grid = new int[gridLength, gridWidth];
            for (int i = 0; i < gridLength; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    grid[i, j] = rnd.Next(0, 2);
                }
            }
            Console.WriteLine("Original Generation");
            PrintGrid(grid, gridLength, gridWidth);
            NextGeneration(grid, gridLength, gridWidth, numGen, 0);
        }

        static void NextGeneration(int[,] grid, int gridLength, int gridWidth, int numGen, int currentGen)
        {
            if (numGen == 0)
            {
                Console.WriteLine("Generation Completed");
            }
            else
            {
                //a temporary grid(shallow copy)
                //int[,] tempGrid = (int[,])grid.Clone();
                //No copy needed instead use dummy value for this particular problem
                int liveNeighbours;
                for (int i = 0; i < gridLength; i++)
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        liveNeighbours = 0;
                        //count the live neighbours of a cell
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                //handle boundary conditions
                                if ((i + k < 0) || (i + k > gridLength - 1) || (j + l < 0) || (j + l > gridWidth - 1))
                                    continue;
                                else if (!(Math.Abs(grid[i + k, j + l]) == 1))
                                    continue;
                                else
                                    liveNeighbours += Math.Abs(grid[i + k, j + l]);
                            }
                        }
                        liveNeighbours -= grid[i, j];//remove self

                        //apply the rules
                        //underpopulation and overpopulation
                        if((grid[i, j] == 1) && ((liveNeighbours > 3) || (liveNeighbours < 2)))
                            grid[i, j] = -1;
                        //Reproduction
                        if (grid[i, j] == 0 && (liveNeighbours == 3))
                            grid[i, j] = 2;
                    }
                }

                for(int i = 0; i < gridLength; i++)
                {
                    for(int j = 0; j < gridWidth; j++)
                    {
                        if (grid[i, j] <= 0)
                            grid[i, j] = 0;
                        else
                            grid[i, j] = 1;
                    }
                }

                Console.WriteLine("GENERATION {0}", currentGen + 1);
                PrintGrid(grid, gridLength, gridWidth);
                NextGeneration(grid, gridLength, gridWidth, numGen - 1, currentGen + 1);
            }
        }

        static void PrintGrid(int[,] grid, int gridLength, int gridWidth)
        {
            for (int i = 0; i < gridLength; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
