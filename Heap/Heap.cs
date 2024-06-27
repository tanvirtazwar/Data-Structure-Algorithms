using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap
    {
        private List<int> heap = [];
        private int leftChild(int index)
        {
            return (2 * index + 1);
        }
        private int rightChild(int index)
        {
            return (2 * index + 2);
        }
        private int parent(int index)
        {
            return ((index - 1) / 2);
        }
        private void swap(int index1, int index2)
        {
            int temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
        private void sinkDown(int index)
        {
            int maxIndex = index;
            while (true)
            {
                int leftIndex = leftChild(index);
                int rightIndex = rightChild(index);

                if (leftIndex < heap.Count &&
                    heap[leftIndex] > heap[maxIndex])
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < heap.Count && 
                    heap[rightIndex] > heap[maxIndex])
                {
                    maxIndex = rightIndex;
                }

                if(maxIndex != index)
                {
                    swap(maxIndex, index);
                    index = maxIndex;
                }
                else
                {
                    return;
                }
            }
        }
        public List<int> getHeap()
        {
            return heap;
        }
        public void printHeap()
        {
            Console.WriteLine("Heap List:");
            foreach (int i in heap)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");
        }
        public void insert(int value)
        {
            heap.Add(value);
            int current = heap.Count - 1;
            while (current > 0 && heap[current] > heap[parent(current)])
            {
                swap(current, parent(current));
                current = parent(current);
            }
        }
        public int? remove()
        {
            if (heap.Count == 0)
            {
                return null;
            }

            if (heap.Count == 1)
            {
                int temp = heap[0];
                heap.RemoveAt(0);
                return temp;
            }

            int maxValue = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            sinkDown(0);

            return maxValue;
        }


        // This method returns k th smallest element in an array 
        public static int? findKthSmallest(int[] nums, int k)
        {
            Heap heap = new Heap();
            foreach (var num in nums)
            {
                heap.insert(num);
            }
            for (int i = 0; i < (nums.Length - k); i++)
            {
                heap.remove();
            }
            return heap.remove();
        }

        public static List<int> streamMax(int[] nums)
        {
            Heap maxHeap = new Heap();
            List<int> maxStream = new List<int>();

            foreach (var num in nums)
            {
                maxHeap.insert(num);
                // The heap's root is always the maximum, so we add it to the result list
                maxStream.Add(maxHeap.getHeap()[0]);
            }

            return maxStream;
        }

    }
}
