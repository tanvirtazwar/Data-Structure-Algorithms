namespace StackQueueArrayList
{
    public class Queue<T>
    {
        private Stack<T> stack1;
        private Stack<T> stack2;

        public Queue()
        {
            stack1 = new Stack<T>();
            stack2 = new Stack<T>();
        }

        public void enqueue(T value)
        {
            while (!stack1.IsEmpty())
            {
                stack2.Push(stack1.Pop());
            }
            stack1.Push(value);
            while (!stack2.IsEmpty())
            {
                stack1.Push(stack2.Pop());
            }
        }

        public T dequeue()
        {
            if (stack1.IsEmpty()) { return default(T); }
            return stack1.Pop();
        }

        public T peek()
        {
            return stack1.Peek();
        }

        public bool isEmpty()
        {
            return stack1.IsEmpty();
        }

    }
}
