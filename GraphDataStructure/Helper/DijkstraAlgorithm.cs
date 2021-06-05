using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class DijkstraAlgorithm
    {
        static int size = 7;

        int[] selected = new int[size];
        int[] cost = new int[size];

        int[,] edges = {
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 50, 45, 10, 0, 0 },
            { 0, 0, 0, 10, 15, 0, 0},
            { 0, 0, 0, 0, 0, 30, 0 },
            { 0, 10, 0, 0, 0, 15, 0 },
            { 0, 0, 20, 35, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 3, 0 }
        };

        internal int[] ShortestPath(int startVertex)
        {
            selected[startVertex] = 1;

            for (int i = 1; i < size; i++)
            {
                if (edges[startVertex, i] == 0 && i != startVertex)
                {
                    cost[i] = int.MaxValue;
                }
                else
                {
                    cost[i] = edges[startVertex, i];
                }
            }

            for (int i = 1; i < size - 1; i++)
            {
                int index = FindMin(startVertex);
                selected[index] = 1;

                for (int j = 1; j < size; j++)
                {
                    if (selected[j] == 0 && edges[index, j] != 0 && (cost[index] + edges[index, j]) < cost[j])
                    {
                        cost[j] = cost[index] + edges[index, j];
                    }
                }
            }

            return cost;
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

        private int FindMin(int startIndex)
        {
            int min = int.MaxValue;
            int i = 1;
            int j = i;

            while (i < size)
            {
                if (i != startIndex && selected[i] == 0 && cost[i] < min)
                {
                    min = cost[i];
                    j = i;
                }

                i++;
            }

            return j;
        }
    }
}
