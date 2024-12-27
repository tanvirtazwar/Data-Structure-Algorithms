namespace Heap;

public class Heap
{
    private readonly List<int> heap = [];
    private static int LeftChild(int index)
    {
        return (2 * index + 1);
    }
    private static int RightChild(int index)
    {
        return (2 * index + 2);
    }
    private static int Parent(int index)
    {
        return ((index - 1) / 2);
    }
    private void Swap(int index1, int index2)
    {
        (heap[index1], heap[index2]) = (heap[index2], heap[index1]);
    }
    private void SinkDown(int index)
    {
        var maxIndex = index;
        while (true)
        {
            var leftIndex = LeftChild(index);
            var rightIndex = RightChild(index);

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
                Swap(maxIndex, index);
                index = maxIndex;
            }
            else
            {
                return;
            }
        }
    }

    private List<int> GetHeap()
    {
        return heap;
    }
    public void PrintHeap()
    {
        Console.WriteLine("Heap List:");
        foreach (var i in heap)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("\n");
    }
    public void Insert(int value)
    {
        heap.Add(value);
        var current = heap.Count - 1;
        while (current > 0 && heap[current] > heap[Parent(current)])
        {
            Swap(current, Parent(current));
            current = Parent(current);
        }
    }
    public int? Remove()
    {
        switch (heap.Count)
        {
            case 0:
                return null;
            case 1:
            {
                var temp = heap[0];
                heap.RemoveAt(0);
                return temp;
            }
        }

        var maxValue = heap[0];
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);
        SinkDown(0);

        return maxValue;
    }


    // This method returns k th the smallest element in an array 
    public static int? FindKthSmallest(int[] nums, int k)
    {
        var heap = new Heap();
        foreach (var num in nums)
        {
            heap.Insert(num);
        }
        for (var i = 0; i < (nums.Length - k); i++)
        {
            heap.Remove();
        }
        return heap.Remove();
    }

    public static List<int> StreamMax(int[] nums)
    {
        var maxHeap = new Heap();
        var maxStream = new List<int>();

        foreach (var num in nums)
        {
            maxHeap.Insert(num);
            // The heap's root is always the maximum, so we add it to the result list
            maxStream.Add(maxHeap.GetHeap()[0]);
        }

        return maxStream;
    }

}