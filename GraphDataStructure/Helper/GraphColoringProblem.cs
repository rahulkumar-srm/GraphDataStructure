using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class GraphColoringProblem
    {
        static int size = 5;
        int colorCount = 3;
        int[] vertexColor = new int[size];

        int[,] edges = {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 1 },
            { 0, 1, 0, 1, 0 },
        };

        internal void SolveGCP()
        {
            Console.WriteLine();

            if (!SolveGCPUntil(1))
            {
                Console.WriteLine("Solution does not exist");
            }
        }

        private bool SolveGCPUntil(int idx)
        {
            if (idx >= size)
            {
                PrintSolution();
                return true;
            }

            bool res = false;

            for (int i = 0; i < colorCount; i++)
            {
                if (CanBeColoured(idx, 1 << i))
                {
                    vertexColor[idx] = 1 << i;
                    res = SolveGCPUntil(idx + 1) || res;
                    vertexColor[idx] = 0;
                }
            }

            return res;
        }

        private bool CanBeColoured(int idx, int mask)
        {
            for (int i = 1; i < size; i++)
            {
                if (edges[idx, i] == 1 && vertexColor[i] == mask)
                {
                    return false;
                }
            }
            return true;
        }

        private void PrintSolution()
        {
            Console.Write("  ");

            for (int i = 1; i < size; i++)
            {
                if (vertexColor[i] == 1 << 0)
                {
                    Console.Write("R");
                }
                else if (vertexColor[i] == 1 << 1)
                {
                    Console.Write("G");
                }
                else
                {
                    Console.Write("B");
                }
            }

            Console.WriteLine();
        }
    }
}
