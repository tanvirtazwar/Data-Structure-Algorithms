namespace DoublyLinkedList;

public class DoublyLinkedList
{

    private Node head;
    private Node tail;
    private int length;

    public class Node(int value)
    {
        public int value = value;
        public Node next;
        public Node prev;
    }

    public DoublyLinkedList(int value)
    {
        Node newNode = new(value);
        head = newNode;
        tail = newNode;
        length = 1;
    }

    public void makeEmpty()
    {
        head = null;
        tail = null;
        length = 0;
    }
    public void printList()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.value);
            temp = temp.next;
        }
    }

    public void getHead()
    {
        if (head == null)
        {
            Console.WriteLine("Head: null");
        }
        else
        {
            Console.WriteLine("Head: " + head.value);
        }
    }

    public void getTail()
    {
        if (head == null)
        {
            Console.WriteLine("Tail: null");
        }
        else
        {
            Console.WriteLine("Tail: " + tail.value);
        }
    }

    public void getLength()
    {
        Console.WriteLine("Length: " + length);
    }

    public void printAll()
    {
        if (length == 0)
        {
            Console.WriteLine("Head: null");
            Console.WriteLine("Tail: null");
        }
        else
        {
            Console.WriteLine("Head: " + head.value);
            Console.WriteLine("Tail: " + tail.value);
        }
        Console.WriteLine("Length:" + length);
        Console.WriteLine("\nDoubly Linked List:");
        if (length == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            printList();
        }
    }

    public void append(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }
        length++;
    }

    public Node removeLast()
    {
        if (length == 0) { return null; }
        Node temp = tail;
        tail = tail.prev;
        length--;
        if (length == 0)
        {
            head = null;
        }
        else
        {
            temp.prev = null;
            tail.next = null;
        }
        return temp;
    }

    public void prepend(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }
        length++;
    }

    public Node removeFirst()
    {
        if (length == 0) { return null; }
        Node temp = head;
        head = head.next;
        length--;
        if (length == 0)
        {
            tail = null;
        }
        else
        {
            temp.next = null;
            head.prev = null;
        }
        return temp;
    }

    public Node get(int index)
    {
        if (index < 0 || index >= length) { return null; }
        Node temp = new Node(0);
        if (index < length / 2)
        {
            temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
        }
        else if (index >= length / 2)
        {
            temp = tail;
            for (int i = length - 1; i > index; i--)
            {
                temp = temp.prev;
            }
        }
        return temp;
    }

    public bool set(int index, int value)
    {
        Node temp = get(index);
        if (temp != null)
        {
            temp.value = value;
            return true;
        }
        return false;
    }

    public bool insert(int index, int value)
    {
        if (index < 0 || index > length) return false;
        if (index == 0)
        {
            prepend(value);
            return true;
        }
        if (index == length)
        {
            append(value);
            return true;
        }
        Node newNode = new Node(value);
        Node before = get(index - 1);
        Node after = before.next;
        newNode.prev = before;
        newNode.next = after;
        before.next = newNode;
        after.prev = newNode;
        length++;
        return true;
    }

    public Node remove(int index)
    {
        if (index < 0 || index >= length) return null;
        if (index == 0) return removeFirst();
        if (index == length - 1) return removeLast();

        Node temp = get(index);

        temp.next.prev = temp.prev;
        temp.prev.next = temp.next;
        temp.next = null;
        temp.prev = null;

        length--;
        return temp;
    }

    //Swap First and Last Node Values in a Doubly Linked List.
    public void swapFirstLast()
    {
        if (length == 0 || length == 1) { return; }

        Node temp = head;
        if (length == 2)
        {
            tail.prev = null;
            head.next = null;
            temp = head;
            head = tail;
            tail = temp;
            head.next = tail;
            tail.prev = head;
            return;
        }
        Node afterHead = head.next;
        head.next = null;
        afterHead.prev = null;

        Node beforeTail = tail.prev;
        tail.prev = null;
        beforeTail.next = null;

        temp = head;
        head = tail;
        tail = temp;

        afterHead.prev = head;
        head.next = afterHead;
        beforeTail.next = tail;
        tail.prev = beforeTail;
    }
    // Alternative easy method for swapFirstLast() from udemy course
    public void altSwapFirstLast()
    {
        if (length < 2) return;
        int temp = head.value;
        head.value = tail.value;
        tail.value = temp;
    }

    //Implement a method called reverse() that reverses the order of the nodes in the list.
    public void reverse()
    {
        if (length == 0) { return; }
        Node temp = head;
        head = tail;
        tail = temp;
        Node after = temp.next;
        Node before = null;
        for (int i = 0; i < length; i++)
        {
            after = temp.next;
            temp.next = before;
            temp.prev = after;
            before = temp;
            temp = after;
        }
    }
    //Alternative easy method for reverse() from udemy course
    public void altReverse()
    {
        Node current = head;
        Node temp = null;

        while (current != null)
        {
            temp = current.prev;
            current.prev = current.next;
            current.next = temp;
            current = current.prev;
        }

        temp = head;
        head = tail;
        tail = temp;
    }

    //Write a method to determine whether a given doubly linked list reads the same forwards and backwards.
    public bool isPalindrome()
    {
        if (length == 0) { return false; }
        Node temp1 = head;
        Node temp2 = tail;
        for (int i = 0; i <= length / 2; i++)
        {
            if (temp1.value == temp2.value)
            {
                temp1 = temp1.next;
                temp2 = temp2.prev;
            }
            else { return false; }
        }
        return true;
    }

    //Implement a method called swapPairs within the class that swaps the values of adjacent nodes in the linked list.
    public void swapPairs()
    {
        if (head == null || head.next == null) { return; }
        Node nOne = head;
        Node nTwo = head.next;
        while (nOne != null && nTwo != null)
        {
            nOne.next = nTwo.next;
            nTwo.next = nOne;
            nTwo.prev = nOne.prev;
            nOne.prev = nTwo;
            if (nTwo.prev != null) { nTwo.prev.next = nTwo; }
            if (nOne.next != null) { nOne.next.prev = nOne; }
            else { break; }
            nTwo = nOne.next.next;
            nOne = nOne.next;
        }
        head = head.prev;
    }

}
