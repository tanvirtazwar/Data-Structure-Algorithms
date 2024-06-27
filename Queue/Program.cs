namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Queue myQueue = new Queue(2);
            myQueue.enqueue(1);
            myQueue.enqueue(2);

            myQueue.printQueue();
        }
    }
}
