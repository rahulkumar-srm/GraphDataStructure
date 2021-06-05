using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class FloydWarshall
    {
        int size = 5;
        int[,] edges = {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 3, int.MaxValue, 7 },
            { 0, 8, 0, 2, int.MaxValue },
            { 0, 5, int.MaxValue, 0, 1 },
            { 0, 2, int.MaxValue, int.MaxValue, 0 }
        };

        public void ShortestPathPair()
        {
            for (int k = 1; k < size; k++)
            {
                for (int i = 1; i < size; i++)
                {
                    for (int j = 1; j < size; j++)
                    {
                        if (edges[i, k] != int.MaxValue && edges[k, j] != int.MaxValue && (edges[i, k] + edges[k, j]) < edges[i, j])
                        {
                            edges[i, j] = edges[i, k] + edges[k, j];
                        }
                    }
                }
            }

            DisplayMatrix();
        }

        private void DisplayMatrix()
        {
            Console.WriteLine("\nShortest path matrix");
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    Console.Write(edges[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
