using GraphDataStructure.Helper;
using System;

namespace GraphDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine
                    ("Please select an option" +
                        Environment.NewLine + "1. Breadth First Search" +
                        Environment.NewLine + "2. Depth First Search" +
                        Environment.NewLine + "3. Prims Minimum Spanning Tree" +
                        Environment.NewLine + "4. Krushkals Minimum Spanning Tree" +
                        Environment.NewLine + "0. Exit"
                    );

                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine(Environment.NewLine + "Input format is not valid. Please try again." + Environment.NewLine);
                }

                if (i == 0)
                {
                    Environment.Exit(0);
                }
                else if (i == 1)
                {
                    Console.WriteLine("Enter the start vertex");
                    Graph graph = new Graph();
                    graph.BFS(Convert.ToInt32(Console.ReadLine()));
                }
                else if (i == 2)
                {
                    Console.WriteLine("Enter the start vertex");
                    Graph graph = new Graph();
                    graph.DFS(Convert.ToInt32(Console.ReadLine()));

                    Console.WriteLine();
                }
                else if (i == 3)
                {
                    PrimsAlgo prims = new PrimsAlgo();
                    prims.PrimsMST();
                }
                else if (i == 4)
                {
                    KruskalsAlgo kruskals = new KruskalsAlgo();
                    kruskals.KruskalsMST();
                }
                else if (i == 5)
                {
                    Console.Write("\nEnter the start vertex : ");
                    int startVertex = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    DijkstraAlgorithm dijkstraAlgorithm = new DijkstraAlgorithm();
                    dijkstraAlgorithm.DisplayShortestPath(dijkstraAlgorithm.ShortestPath(startVertex), startVertex);

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
    }
}
