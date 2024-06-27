namespace StackQueueArrayList
{
    public class Stack<T>
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
                return default(T);
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
            if (IsEmpty()) return default(T);
            var indexValue = stackList[stackList.Count - 1];
            stackList.RemoveAt(stackList.Count - 1);
            return indexValue;
        }

    }
}
