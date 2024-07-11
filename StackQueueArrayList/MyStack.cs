namespace MyStackQueueArrayList
{
    public class MyStack<T>
    {

        private readonly List<T> stackList = new List<T>();

        public List<T> GetStackList()
        {
            return stackList;
        }

        public void PrintStack()
        {
            for (int i = stackList.Count() - 1; i >= 0; i--)
            {
                Console.WriteLine(stackList[i]);
            }
        }

        public bool IsEmpty()
        {
            return stackList.Count() == 0;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                return default;
            }
            else
            {
                return stackList[stackList.Count() - 1];
            }
        }

        public int Size()
        {
            return stackList.Count();
        }

        public void Push(T value)
        {
            stackList.Add(value);
        }

        public T Pop()
        {
            if (IsEmpty()) return default;
            var indexValue = stackList[stackList.Count - 1];
            stackList.RemoveAt(stackList.Count - 1);
            return indexValue;
        }

    }

    public class MyStack
    {
        private Queue<int> queue1;
        private Queue<int> queue2;

        public MyStack()
        {
            queue1 = new Queue<int>();
            queue2 = new Queue<int>();
        }

        public void Push(int x)
        {
            while (queue1.Count > 0)
            {
                queue2.Enqueue(queue1.Dequeue());
            }
            queue1.Enqueue(x);
            while (queue2.Count > 0)
            {
                queue1.Enqueue(queue2.Dequeue());
            }
        }

        public int Pop()
        {
            return queue1.Dequeue();
        }

        public int Top()
        {
            return queue1.Peek();
        }

        public bool Empty()
        {
            return queue1.Count == 0;
        }
    }
}
