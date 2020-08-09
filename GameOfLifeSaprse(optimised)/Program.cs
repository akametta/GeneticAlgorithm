using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmSparseOptimised
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
                //find the co-ordinates of live cells
                var list = new List<Tuple<int, int>>();
                for (int i = 0; i < gridLength; i++)
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        if (grid[i, j] == 1)
                            list.Add(new Tuple<int, int>(i, j));
                    }
                }

                Dictionary<Tuple<int, int>, int> Dict = new Dictionary<Tuple<int, int>, int>();
                foreach (var v in list)
                {
                    for (int i = v.Item1 - 1; (i < v.Item1 + 2); i++)
                    {
                        for (int j = v.Item2 - 1; (j < v.Item2 + 2); j++)
                        {
                            if ((i < 0) || (i > gridLength) || (j < 0) || (j > gridWidth) || (i == v.Item1 && j == v.Item2))
                                continue;
                            else
                            {
                                var neighbour = new Tuple<int, int>(i, j);
                                if (Dict.ContainsKey(neighbour))
                                {
                                    Dict[neighbour] = Dict[neighbour] + 1;
                                }
                                else
                                    Dict.Add(neighbour, 1);
                            }

                        }
                    }
                }
                var updatelist = new List<Tuple<int, int>>();
                foreach (var v in Dict)
                {
                    if ((v.Value == 3) || (v.Value == 2 && list.Contains(v.Key)))
                    {
                        updatelist.Add(v.Key);
                    }
                }
                for (int i = 0; i < gridLength; i++)
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        var v = new Tuple<int, int>(i, j);
                        if (updatelist.Contains(v))
                        {
                            grid[i, j] = 1;
                        }
                        else
                            grid[i, j] = 0;
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
