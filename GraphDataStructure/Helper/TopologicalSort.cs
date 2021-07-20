using GraphDataStructure.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Helper
{
    class TopologicalSort
    {
        public List<int> solve(int A, List<List<int>> B)
        {
            int[] indegree = new int[A + 1];
            List<int> ans = new List<int>();
            MinHeap minHeap = new MinHeap();
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < B.Count; i++)
            {
                if (!graph.ContainsKey(B[i][0]))
                    graph[B[i][0]] = new List<int>();

                graph[B[i][0]].Add(B[i][1]);
                indegree[B[i][1]]++;
            }

            for (int i = 1; i <= A; i++)
            {
                if (indegree[i] == 0)
                    minHeap.Insert(i);
            }

            while (minHeap.Size() > 0)
            {
                int node = minHeap.Delete();
                ans.Add(node);

                if (graph.ContainsKey(node))
                {
                    foreach (int vertex in graph[node])
                    {
                        if (--indegree[vertex] == 0)
                            minHeap.Insert(vertex);
                    }
                }
            }

            if (ans.Count < A)
                return new List<int>();

            return ans;
        }
    }
}
