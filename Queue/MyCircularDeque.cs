using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class MyCircularDeque
    {
        private Node first;
        private Node last;
        private int length;
        private int currentLength;

        public class Node
        {
            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public MyCircularDeque(int length)
        {
            this.length = length;
            currentLength = 0;
            first = null;
            last = null;
        }

        public bool InsertFront(int value)
        {
            if (currentLength == length)
            {
                return false;
            }

            Node newNode = new Node(value);
            if (currentLength == 0)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.next = first;
                first = newNode;
            }
            currentLength++;
            return true;
        }

        public bool InsertLast(int value)
        {
            if (currentLength == length)
            {
                return false;
            }

            Node newNode = new Node(value);
            if (currentLength == 0)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                last = newNode;
            }
            currentLength++;
            return true;
        }

        public bool DeleteFront()
        {
            if (currentLength == 0)
            {
                return false;
            }
            else if (currentLength == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                Node temp = first;
                first = first.next;
                temp.next = null;
            }
            currentLength--;
            return true;
        }

        public bool DeleteLast()
        {
            if (currentLength == 0)
            {
                return false;
            }
            else if (currentLength == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                Node temp = first;
                while (temp.next != last)
                {
                    temp = temp.next;
                }
                temp.next = null;
                last = temp;
            }
            currentLength--;
            return true;
        }

        public int GetFront()
        {
            if (currentLength == 0)
            {
                return -1;
            }
            return first.value;
        }

        public int GetRear()
        {
            if (currentLength == 0)
            {
                return -1;
            }
            return last.value;
        }

        public bool IsEmpty()
        {
            if (currentLength == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            if (currentLength == length)
            {
                return true;
            }
            return false;
        }
    }
}
