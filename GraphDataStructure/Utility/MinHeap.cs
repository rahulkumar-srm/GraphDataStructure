using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDataStructure.Utility
{
    class MinHeap
    {
        public int top;
        public List<int> heap;

        public MinHeap()
        {
            top = -1;
            heap = new List<int>();
        }

        public int Size()
        {
            return top + 1;
        }

        public void Insert(int num)
        {
            int i = ++top;
            heap.Add(0);

            while (i > 0 && heap[(i - 1) / 2] > num)
            {
                heap[i] = heap[(i - 1) / 2];
                i = (i - 1) / 2;
            }

            heap[i] = num;
        }

        public int Delete()
        {
            int res = heap[0];
            heap[0] = heap[top];
            heap[top--] = 0;

            int i = 0, j = 2 * i + 1;

            while (j <= top)
            {
                if (j < top && heap[j + 1] < heap[j])
                    j += 1;

                if (heap[j] < heap[i])
                {
                    int temp = heap[j];
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
}
