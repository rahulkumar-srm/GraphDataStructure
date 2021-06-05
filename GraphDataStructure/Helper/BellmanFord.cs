using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class BellmanFord
    {
        int size = 8;

        int[,] edges = {
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 6, 5, 5, 0, 0, 0 },
            { 0, 0, 0, 0, 0, -1, 0, 0 },
            { 0, 0, -2, 0, 0, 1, 0, 0 },
            { 0, 0, 0, -2, 0, 0, -1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 3 },
            { 0, 0, 0, 0, 0, 0, 0, 3 },
            { 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        int[] cost = { 0, 0, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };

        internal void ShortestPathPair()
        {
            for (int k = 1; k < size - 1; k++)
            {
                for (int i = 1; i < size; i++)
                {
                    for (int j = 1; j < size; j++)
                    {
                        int q = cost[i] + edges[i, j];
                        if (edges[i, j] != 0 && q < cost[j] && cost[i] < int.MaxValue)
                        {
                            cost[j] = q;
                        }
                    }
                }
            }

            Console.WriteLine();
            DisplayShortestPath(cost, 1);
        }

        internal void DisplayShortestPath(int[] path, int startIndex)
        {
            for (int i = 1; i < size; i++)
            {
                if (i != startIndex)
                {
                    Console.WriteLine($"Shortest path from vertext {startIndex} to vertex {i} : {path[i]}");
                }
            }
        }
    }
}
