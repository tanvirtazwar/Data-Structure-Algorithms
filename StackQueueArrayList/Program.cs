namespace MyStackQueueArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            MyQueue myQueue = new MyQueue();
            myQueue.Push(1);
            myQueue.Push(2);
            Console.WriteLine(myQueue.Peek());
            Console.WriteLine(myQueue.Pop());
            Console.WriteLine(myQueue.Pop());
            Console.WriteLine(myQueue.Empty());
        }
    }
}
