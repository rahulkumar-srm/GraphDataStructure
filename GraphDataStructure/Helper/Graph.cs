using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class Graph
    {
        int[,] A = new int[,]{{0, 0, 0, 0, 0, 0, 0, 0},
                              {0, 0, 1, 1, 1, 0, 0, 0},
                              {0, 1, 0, 1, 0, 0, 0, 0},
                              {0, 1, 1, 0, 1, 1, 0, 0},
                              {0, 1, 0, 1, 0, 1, 0, 0},
                              {0, 0, 0, 1, 1, 0, 1, 1},
                              {0, 0, 0, 0, 0, 1, 0, 0},
                              {0, 0, 0, 0, 0, 1, 0, 0}};

        int[] visited = new int[8];

        internal void BFS(int startVertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startVertex);

            Console.Write(startVertex + " ");
            visited[startVertex] = 1;

            while (queue.Count > 0)
            {
                int item = queue.Dequeue();

                for(int i = 1; i < A.GetLength(0); i++)
                {
                    if(A[item, i] == 1 && visited[i] == 0)
                    {
                        Console.Write(i  + " ");
                        queue.Enqueue(i);
                        visited[i] = 1;
                    }
                }
            }

            Array.Clear(visited, 0, 8);

            Console.WriteLine();
        }

        internal void DFS(int vertex)
        {
            if (visited[vertex] == 0)
            {
                Console.Write(vertex + " ");
                visited[vertex] = 1;

                for (int i = 1; i < A.GetLength(0); i++)
                {
                    if(A[vertex, i] == 1  && visited[i] == 0)
                    {
                        DFS(i);
                    }
                }
            }
        }
    }
}
