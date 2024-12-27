namespace Heap;

public class MaxHeap<T> where T : IComparable<T>
{
    private readonly List<T> heap = [];

    public T this[int index] => heap[index];
    
    public int Count => heap.Count;

    public void Insert(T item)
    {
        heap.Add(item);
        var index = heap.Count - 1;
        var parentIndex = (index - 1) / 2;

        while (index > 0 && heap[index].CompareTo(heap[parentIndex]) > 0)
        {
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    public T ExtractMax()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }
        
        var max = heap[0];
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);
        SinkDown(0);
        return max;
    }

    private void SinkDown(int index)
    {
        while (true)
        {
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var largestIndex = index;

            if (leftChildIndex < heap.Count 
                && heap[leftChildIndex].CompareTo(heap[largestIndex]) > 0)
            {
                largestIndex = leftChildIndex;
            }

            if (rightChildIndex < heap.Count 
                && heap[rightChildIndex].CompareTo(heap[largestIndex]) > 0)
            {
                largestIndex = rightChildIndex;
            }

            if (largestIndex == index) return;
            Swap(index, largestIndex);
            index = largestIndex;
        }
    }

    private void Swap(int i, int j)
    {
        (heap[i], heap[j]) = (heap[j], heap[i]);
    }
}