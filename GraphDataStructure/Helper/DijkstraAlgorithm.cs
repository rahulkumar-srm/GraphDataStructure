using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    internal class DijkstraAlgorithm
    {
        public List<int> solve(int A, List<List<int>> B, int C)
        {
            List<int> dist = new List<int>();
            bool[] visited = new bool[A];
            MinHeapWithNode heap = new MinHeapWithNode();
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

            for (int i = 0; i < A; i++)
                dist.Add(int.MaxValue);

            foreach (var edge in B)
            {
                if (!graph.ContainsKey(edge[0]))
                    graph[edge[0]] = new Dictionary<int, int>();

                graph[edge[0]][edge[1]] = edge[2];

                if (!graph.ContainsKey(edge[1]))
                    graph[edge[1]] = new Dictionary<int, int>();

                graph[edge[1]][edge[0]] = edge[2];
            }

            dist[C] = 0;
            heap.Insert(new Node(C, 0));

            while (heap.Size() > 0)
            {
                Node node = heap.Delete();
                if (!visited[node.vertex] && graph.ContainsKey(node.vertex))
                {
                    visited[node.vertex] = true;
                    foreach (var vertex in graph[node.vertex])
                    {
                        if (!visited[vertex.Key])
                        {
                            int temp = dist[node.vertex] + vertex.Value;
                            if (temp < dist[vertex.Key])
                            {
                                dist[vertex.Key] = temp;
                                heap.Insert(new Node(vertex.Key, temp));
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < dist.Count; i++)
            {
                if (dist[i] == int.MaxValue)
                    dist[i] = -1;
            }

            return dist;
        }
    }

    class MinHeapWithNode
    {
        public int top;
        public List<Node> heap;

        public MinHeapWithNode()
        {
            top = -1;
            heap = new List<Node>();
        }

        public int Size()
        {
            return top + 1;
        }

        public void Insert(Node node)
        {
            int i = ++top;
            heap.Add(null);

            while (i > 0 && heap[(i - 1) / 2].weight > node.weight)
            {
                heap[i] = heap[(i - 1) / 2];
                i = (i - 1) / 2;
            }

            heap[i] = node;
        }

        public Node Delete()
        {
            Node res = heap[0];
            heap[0] = heap[top];
            heap[top--] = null;

            int i = 0, j = 2 * i + 1;

            while (j <= top)
            {
                if (j < top && heap[j + 1].weight < heap[j].weight)
                    j += 1;

                if (heap[j].weight < heap[i].weight)
                {
                    Node temp = heap[j];
                    heap[j] = heap[i];
                    heap[i] = temp;

                    i = j;
                    j = 2 * i + 1;
                }
                else
                    break;
            }

            return res;
        }
    }

    class Node
    {
        public int vertex;
        public int weight;

        public Node(int vertex, int weight)
        {
            this.vertex = vertex;
            this.weight = weight;
        }
    }
}
