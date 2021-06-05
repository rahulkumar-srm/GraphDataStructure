using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class HamiltonianCycle
    {
        static int size = 6;

        int[,] edges = {
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0, 1 },
            { 0, 1, 0, 1, 1, 1 },
            { 0, 1, 1, 0, 1, 0 },
            { 0, 0, 1, 1, 0, 1 },
            { 0, 1, 1, 0, 1, 0 }
        };

        int[] path = new int[size];

        internal void SolveHC()
        {
            Console.WriteLine();

            path[0] = 1;

            if (!SolveHCUntil(1, 1, 1))
            {
                Console.WriteLine("Solution does not exist");
            }
        }

        private bool SolveHCUntil(int startVertex, int previousVertex, int idx)
        {
            if (idx == size - 1)
            {
                if (edges[path[idx - 1], startVertex] == 0)
                {
                    return false;
                }

                path[idx] = startVertex;
                PrintSolution();
                return true;
            }

            bool res = false;

            for (int i = 1; i < size; i++)
            {
                if (IsValid(startVertex, previousVertex, i))
                {
                    path[idx] = i;
                    res = SolveHCUntil(startVertex, i, idx + 1) || res;
                    path[idx] = 0;
                }
            }

            return res;
        }

        private bool IsValid(int startVertex, int previousVertex, int currentVertex)
        {
            int i = 0;

            while (i < size && path[i] != 0)
            {
                if (path[i++] == currentVertex)
                {
                    return false;
                }
            }

            if (edges[previousVertex, currentVertex] == 0)
            {
                return false;
            }

            return true;
        }

        private void PrintSolution()
        {
            Console.Write("  ");

            for (int i = 0; i < size; i++)
            {
                Console.Write(path[i]);
            }

            Console.WriteLine();
        }
    }
}
