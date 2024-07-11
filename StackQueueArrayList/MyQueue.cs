namespace MyStackQueueArrayList
{
    public class MyQueue<T>
    {
        private MyStack<T> stack1;
        private MyStack<T> stack2;

        public MyQueue()
        {
            stack1 = new MyStack<T>();
            stack2 = new MyStack<T>();
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
            if (stack1.IsEmpty()) { return default; }
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

    public class MyQueue
    {

        private Stack<int> stack1;
        private Stack<int> stack2;

        public MyQueue()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Push(int x)
        {
            while (stack1.Count() > 0)
            {
                stack2.Push(stack1.Pop());
            }
            stack1.Push(x);
            while (stack2.Count() > 0)
            {
                stack1.Push(stack2.Pop());
            }
        }

        public int Pop()
        {
            return stack1.Pop();
        }

        public int Peek()
        {
            return stack1.Peek();
        }

        public bool Empty()
        {
            if (stack1.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
