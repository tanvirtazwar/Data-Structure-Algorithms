namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! 2");

            Stack myStack = new Stack(2);
            myStack.push(1);

            // (2) Items - Returns 1 Node
            Console.WriteLine(myStack.pop().value);
            // (1) Item - Returns 2 Node
            Console.WriteLine(myStack.pop().value);
            // (0) Items - Returns null
            Console.WriteLine(myStack.pop());
        }
    }
}
