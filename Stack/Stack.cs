namespace Stack
{
    public class Stack
    {
        private Node top;
        private int height;

        public class Node
        {
            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public Stack(int value)
        {
            Node newNode = new(value);
            top = newNode;
            height = 1;
        }

        public void printStack()
        {
            Node temp = top;
            while (temp != null)
            {
                Console.WriteLine(temp.value);
                temp = temp.next;
            }
        }

        public void getTop()
        {
            if (top == null)
            {
                Console.WriteLine("Top: null");
            }
            else
            {
                Console.WriteLine("Top: " + top.value);
            }
        }

        public void getHeight()
        {
            Console.WriteLine("Height: " + height);
        }

        public void push(int value)
        {
            Node newNode = new(value);
            if (height == 0)
            {
                top = newNode;
            }
            else
            {
                newNode.next = top;
                top = newNode;
            }
            height++;
        }

        public Node pop()
        {
            if (height == 0) return null;

            Node temp = top;
            top = top.next;
            temp.next = null;

            height--;
            return temp;
        }
    }
}
