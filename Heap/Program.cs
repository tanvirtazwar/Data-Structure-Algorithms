namespace Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap();
            heap.insert(99);
            heap.insert(72);
            heap.insert(61);
            heap.printHeap();
            heap.insert(58);
            heap.printHeap();
            heap.insert(100);
            heap.printHeap();
            heap.insert(75);
            heap.printHeap();
            heap.remove();
            heap.printHeap();
            heap.remove();
            heap.printHeap();

            int[] nums1 = { 7, 10, 4, 3, 20, 15 };
            int k1 = 3;
            Console.WriteLine(Heap.findKthSmallest(nums1, k1));

            int[] nums2 = { 2, 1, 3, 5, 6, 4 };
            int k2 = 2;
            Console.WriteLine(Heap.findKthSmallest(nums2, k2));

            int[] nums3 = { 9, 3, 2, 11, 7, 10, 4, 5 };
            int k3 = 5;
            Console.WriteLine(Heap.findKthSmallest(nums3, k3));

            int[] nums4 = { 1, 5, 2, 9, 3, 6, 8 };
            var result4 = Heap.streamMax(nums4);
            foreach(int i in result4)
            {
                Console.Write(i+", "); 
            }

            Console.WriteLine("\n");

            int[] nums5 = { 10, 2, 5, 1, 0, 11, 6 , 8 };
            var result5 = Heap.streamMax(nums5);
            foreach (int i in result5)
            {
                Console.Write(i+", ");
            }

        }
    }
}
