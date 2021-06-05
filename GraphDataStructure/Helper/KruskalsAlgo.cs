using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class KruskalsAlgo
    {
        private const int size = 8;

        int[,] edges = new int[3, size + 1]{{ 1, 1,  2,  2, 3,  4,  4,  5,  5},
                                            { 2, 6,  3,  7, 4,  5,  7,  6,  7},
                                            {25, 5, 12, 10, 8, 16, 14, 20, 18}};

        int[] included = new int[size + 1];

        int[] parent = new int[size] { -1, -1, -1, -1, -1, -1, -1, -1 };

        int[,] track = new int[2, size - 2];

        internal void KruskalsMST()
        {
            int i = 0;

            while (i < size - 2)
            {
                int min = int.MaxValue, vertex1 = 0, vertex2 = 0, k = 0;

                for (int j = 0; j < size + 1; j++)
                {
                    if (included[j] == 0 && edges[2, j] < min)
                    {
                        min = edges[2, j];
                        vertex1 = edges[0, j];
                        vertex2 = edges[1, j];
                        k = j;
                    }
                }

                int pVertex1 = CollapseFind(vertex1, parent);
                int pVertex2 = CollapseFind(vertex2, parent);

                if (pVertex1 != pVertex2)
                {
                    WeightedUnion(pVertex1, pVertex2, parent);

                    track[0, i] = vertex1;
                    track[1, i] = vertex2;

                    i++;
                }

                included[k] = 1;
            }

            DisplayKruskalsMST(track);
        }

        private void WeightedUnion(int vertex1, int vertex2, int[] parent)
        {
            if(parent[vertex1] < parent[vertex2])
            {
                parent[vertex1] += parent[vertex2];
                parent[vertex2] = vertex1;
            }
            else
            {
                parent[vertex2] += parent[vertex1];
                parent[vertex1] = vertex2;
            }
        }

        private int CollapseFind(int vertex, int[] parents)
        {
            int temp = vertex;
            int parent;

            while (parents[vertex] > 0)
            {
                vertex = parents[vertex];
            }

            while(temp != vertex)
            {
                parent = parents[temp];
                parents[temp] = vertex;
                temp = parent;
            }

            return vertex;
        }

        private void DisplayKruskalsMST(int[,] items)
        {
            for (int i = 0; i < size - 2; i++)
            {
                Console.Write(items[0, i] + " " + items[1, i] + " ");
            }

            Console.WriteLine();
        }
    } 
}
