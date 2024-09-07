using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class MinStack
    {

        private Stack<Node> stack;

        public class Node
        {
            public int value;
            public int minValue;

            public Node(int value, int minValue)
            {
                this.value = value;
                this.minValue = minValue;
            }
        }

        public MinStack()
        {
            stack = new Stack<Node>();
        }

        public void Push(int val)
        {
            if (stack.Count == 0)
            {
                Node newNode = new Node(val, val);
                stack.Push(newNode);
            }
            else
            {
                int minVal = Math.Min(stack.Peek().minValue, val);
                Node newNode = new Node(val, minVal);
                stack.Push(newNode);
            }

        }

        public void Pop()
        {
            if (stack.Count == 0)
            {
                return;
            }
            stack.Pop();
        }

        public int Top()
        {
            if (stack.Count == 0)
            {
                return 0;
            }
            return stack.Peek().value;
        }

        public int GetMin()
        {
            if (stack.Count == 0)
            {
                return 0;
            }
            return stack.Peek().minValue;
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(val);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
