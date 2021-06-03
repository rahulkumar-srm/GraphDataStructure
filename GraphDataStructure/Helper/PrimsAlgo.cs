using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class PrimsAlgo
    {
        static int maxValue = int.MaxValue;
        static int size = 8;

        int[,] Cost = new int[,]{{maxValue, maxValue, maxValue, maxValue, maxValue, maxValue, maxValue, maxValue},
                              {maxValue, maxValue, 25, maxValue, maxValue, maxValue, 5, maxValue},
                              {maxValue, 25, maxValue, 12, maxValue, maxValue, maxValue, 10},
                              {maxValue, maxValue, 12, maxValue, 8, maxValue, maxValue, maxValue},
                              {maxValue, maxValue, maxValue, 8, maxValue, 16, maxValue, 14},
                              {maxValue, maxValue, maxValue, maxValue, 16, maxValue, 20, 18},
                              {maxValue, 5, maxValue, maxValue, maxValue, 20, maxValue, maxValue},
                              {maxValue, maxValue, 10, maxValue, 14, 18, maxValue, maxValue}};

        int[,] track = new int[2, size - 2];

        int[] included = new int[size];

        internal void PrimsMST()
        {
            int min = maxValue, vertex1 = 0, vertex2 = 0;

            //Find first minimum edge
            for(int i = 0; i < size; i++)
            {
                included[i] = maxValue;

                for(int j = i; j < size; j++)
                {
                    if(Cost[i,j] < min)
                    {
                        min = Cost[i, j];
                        vertex1 = i;
                        vertex2 = j;
                    }
                }
            }

            //Add first minimum cost vertices
            track[0, 0] = vertex1;
            track[1, 0] = vertex2;

            //Update to keep track of already added vertices
            included[vertex1] = 0;
            included[vertex2] = 0;

            //Initialize track array to track min cost edges
            for (int i = 1; i < size; i++)
            {
                if(included[i] != 0)
                {
                    if(Cost[i, vertex2] > Cost[i, vertex1])
                    {
                        included[i] = vertex1;
                    }
                    else
                    {
                        included[i] = vertex2;
                    }
                }
            }

            //Repeat task
            for (int i = 1; i < size - 2; i++)
            {
                min = maxValue;

                for (int j = 1; j < size; j++)
                {
                    if (included[j] != 0 && Cost[j, included[j]] < min)
                    {
                        min = Cost[j, included[j]];
                        vertex1 = j;
                        vertex2 = included[j];
                    }
                }

                track[0, i] = vertex1;
                track[1, i] = vertex2;

                included[vertex1] = 0;

                // Update track array to track min cost edges
                for (int j = 1; j < size; j++)
                {
                    if (included[j] != 0 && Cost[j, vertex1] < Cost[j, included[j]])
                    {
                        included[j] = vertex1;
                    }
                }
            }

            DisplayPrimsMST(track);
        }

        private void DisplayPrimsMST(int[,] items)
        {
            for(int i = 0; i < size - 2; i++)
            {
                Console.Write(items[0, i] + " " + items[1, i] + " ");
            }

            Console.WriteLine();
        }
    }
}
