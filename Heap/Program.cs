namespace Heap;

internal abstract class Program
{
    private static void Main()
    {
        var heap = new Heap();
        heap.Insert(99);
        heap.Insert(72);
        heap.Insert(61);
        heap.PrintHeap();
        heap.Insert(58);
        heap.PrintHeap();
        heap.Insert(100);
        heap.PrintHeap();
        heap.Insert(75);
        heap.PrintHeap();
        heap.Remove();
        heap.PrintHeap();
        heap.Remove();
        heap.PrintHeap();

        int[] nums1 = [7, 10, 4, 3, 20, 15];
        const int k1 = 3;
        Console.WriteLine(Heap.FindKthSmallest(nums1, k1));

        int[] nums2 = [2, 1, 3, 5, 6, 4];
        const int k2 = 2;
        Console.WriteLine(Heap.FindKthSmallest(nums2, k2));

        int[] nums3 = [9, 3, 2, 11, 7, 10, 4, 5];
        const int k3 = 5;
        Console.WriteLine(Heap.FindKthSmallest(nums3, k3));

        int[] nums4 = [1, 5, 2, 9, 3, 6, 8];
        var result4 = Heap.StreamMax(nums4);
        foreach(var i in result4)
        {
            Console.Write(i+", "); 
        }

        Console.WriteLine("\n");

        int[] nums5 = [10, 2, 5, 1, 0, 11, 6 , 8];
        var result5 = Heap.StreamMax(nums5);
        foreach (var i in result5)
        {
            Console.Write(i+", ");
        }
        Console.WriteLine("\n");
        Console.WriteLine("Testing MaxHeap");
        Console.WriteLine(LastStoneWeight([1, 1]));
    }

    private static int LastStoneWeight(int[] stones)
    {
        var heap = new MaxHeap<int>();

        foreach (var i in stones)
        {
            heap.Insert(i);
        }
        
        while (heap.Count > 1)
        {
            var y = heap.ExtractMax();
            var x = heap.ExtractMax();
            if (y > x)
            {
                heap.Insert(y - x);
            }
        }

        if (heap.Count == 0)
        {
            heap.Insert(0);
        }
        return heap.ExtractMax();
    }
}