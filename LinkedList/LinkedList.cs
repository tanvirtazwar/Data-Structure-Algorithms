namespace LinkedList;

public class LinkedList
{

    private Node head;
    private Node tail;
    private int length;

    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    public LinkedList(int value)
    {
        Node newNode = new Node(value);
        head = newNode;
        tail = newNode;
        length = 1;
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

    public void printHead()
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

    public void printTail()
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

    public void printLength()
    {
        Console.WriteLine("Length: " + length);
    }

    public Node getHead()
    {
        return head;
    }

    public Node getTail()
    {
        return tail;
    }

    public int getLength()
    {
        return length;
    }

    public void makeEmpty()
    {
        head = null;
        tail = null;
        length = 0;
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
            tail = newNode;
        }
        length++;
    }

    public Node removeLast()
    {
        if (length == 0) return null;
        Node temp = head;
        Node pre = head;
        while (temp.next != null)
        {
            pre = temp;
            temp = temp.next;
        }
        tail = pre;
        tail.next = null;
        length--;
        if (length == 0)
        {
            head = null;
            tail = null;
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
            head = newNode;
        }
        length++;
    }

    public Node removeFirst()
    {
        if (length == 0) return null;
        Node temp = head;
        head = head.next;
        temp.next = null;
        length--;
        if (length == 0)
        {
            tail = null;
        }
        return temp;
    }

    public Node get(int index)
    {
        if (index < 0 || index >= length) return null;
        Node temp = head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.next;
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
        Node temp = get(index - 1);
        newNode.next = temp.next;
        temp.next = newNode;
        length++;
        return true;
    }

    public Node remove(int index)
    {
        if (index < 0 || index >= length) return null;
        if (index == 0) return removeFirst();
        if (index == length - 1) return removeLast();

        Node prev = get(index - 1);
        Node temp = prev.next;

        prev.next = temp.next;
        temp.next = null;
        length--;
        return temp;
    }

    public void reverse()
    {
        Node temp = head;
        head = tail;
        tail = temp;
        Node after = temp.next;
        Node before = null;
        for (int i = 0; i < length; i++)
        {
            after = temp.next;
            temp.next = before;
            before = temp;
            temp = after;
        }
    }

    /*Implement a method called findMiddleNode 
     * that returns the middle node of the linked list.
     * If the list has an even number of nodes, 
     * the method should return the second middle node.*/
    public Node findMiddleNode()
    {
        Node slow = head;
        Node fast = head;
        while (fast != null)
        {
            fast = fast.next;
            if (fast == null) { break; }
            fast = fast.next;
            slow = slow.next;
            if (fast == null) { break; }
        }
        return slow;
    }

    /*Write a method called hasLoop that is part of the linked list class.
     * The method should be able to detect if there is a cycle or loop present in the linked list.
     * You are required to use Floyd's cycle-finding algorithm to detect the loop.*/
    public bool hasLoop()
    {
        Node slow = head;
        Node fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }

    /*Implement a method called findKthFromEnd that returns the k-th node from the end of the list.
     * If the list has fewer than k nodes, the method should return null.*/
    public Node findKthFromEnd(int k)
    {
        Node pre = head;
        Node temp = head;
        int count = 0;
        while (pre != null)
        {
            pre = pre.next;
            count++;
        }
        if (count < k)
        {
            return null;
        }
        else
        {
            for (int i = 0; i < count - k; i++)
            {
                temp = temp.next;
            }
        }
        return temp;
    }

    /*Given a value x you need to rearrange the linked list such that all nodes with a value less than x 
     * come before all nodes with a value greater than or equal to x.
     * Additionally, the relative order of nodes in both partitions should remain unchanged.*/
    public void partitionList(int x)
    {
        Node temp = head;
        Node highHead = null;
        Node highTail = null;
        Node lowHead = null;
        Node lowTail = null;
        while (temp != null)
        {
            if (temp.value >= x)
            {
                if (highHead != null)
                {
                    highTail.next = temp;
                    highTail = temp;
                }
                else
                {
                    highHead = temp;
                    highTail = temp;
                }
            }
            else
            {
                if (lowHead != null)
                {
                    lowTail.next = temp;
                    lowTail = temp;
                }
                else
                {
                    lowHead = temp;
                    lowTail = temp;
                }
            }
            temp = temp.next;
        }
        if (lowHead != null)
        {
            head = lowHead;
            lowTail.next = highHead;
        }
        else { head = highHead; }
        if (highTail != null) { highTail.next = null; }
    }

    /*Your task is to implement a method called removeDuplicates() within the LinkedList class 
     * that removes all duplicate values from the list.*/
    public void removeDuplicates()
    {
        if (head == null) { return; }
        Node pre = head;
        while (pre != null)
        {
            if (pre.next == null) { break; }
            Node temp = pre.next;
            Node check = pre;
            while (temp != null)
            {
                if (pre.value == temp.value)
                {
                    check.next = temp.next;
                    temp.next = null;
                    temp = check.next;
                }
                else
                {
                    temp = temp.next;
                    check = check.next;
                }
            }
            pre = pre.next;
        }
    }

    /*You have a linked list where each node represents a binary digit (0 or 1). 
     * The goal of the binaryToDecimal function is to convert this binary number, 
     * represented by the linked list, into its decimal equivalent.*/
    public int binaryToDecimal()
    {
        int num = 0;
        Node temp = head;
        while (temp != null)
        {
            num = num * 2 + temp.value;
            temp = temp.next;
        }
        return num;
    }

    public void swapBetween(int m, int n)
    {
        Node preStart = null;
        Node start = null;
        Node postStart = null;
        Node preEnd = null;
        Node end = null;
        Node postEnd = null;

        if (n - m > 1)
        {
            Node temp = head;
            Node pre = null;
            int count = 0;
            while (temp != null)
            {
                if (count == m)
                {
                    preStart = pre;
                    start = temp;
                    postStart = temp.next;
                }
                else if (count == n)
                {
                    preEnd = pre;
                    end = temp;
                    postEnd = temp.next;
                    break;
                }
                count++;
                pre = temp;
                temp = temp.next;
            }
            if (m != 0) { preStart.next = end; }
            else { head = end; }
            end.next = postStart;
            preEnd.next = start;
            start.next = postEnd;
        }
        else if (n - m == 1)
        {
            Node temp = head;
            Node pre = null;
            int count = 0;
            while (temp != null)
            {
                if (count == m)
                {
                    preStart = pre;
                    start = temp;
                }
                else if (count == n)
                {
                    end = temp;
                    postEnd = temp.next;
                    break;
                }
                count++;
                pre = temp;
                temp = temp.next;
            }
            if (m != 0) { preStart.next = end; }
            else { head = end; }
            end.next = start;
            start.next = postEnd;
        }
    }

    /*In the LinkedList class, implement a method called reverseBetween that reverses the nodes of the list 
     * between indexes startIndex and endIndex (inclusive).*/
    public void reverseBetween(int m, int n)
    {
        if (head == null) { return; }
        Node preStart = null;
        Node start = null;
        Node end = null;
        Node postEnd = null;

        if (n - m > 1)
        {
            Node pre = null;
            Node temp = head;
            Node post = temp.next;
            int count = 0;
            while (temp != null)
            {
                if (m >= count || count >= n)
                {
                    if (count == m)
                    {
                        preStart = pre;
                        start = temp;
                    }
                    else if (count == n)
                    {
                        temp.next = pre;
                        end = temp;
                        pre = temp;
                        postEnd = post;
                        temp = post;
                        break;

                    }
                    pre = temp;
                    temp = temp.next;
                    post = temp.next;
                }
                else if (m < count && count < n)
                {
                    temp.next = pre;
                    pre = temp;
                    temp = post;
                    post = temp.next;
                }

                count++;
            }
            if (m != 0) { preStart.next = end; }
            else { head = end; }
            start.next = postEnd;

        }
        else if (n - m == 1)
        {
            Node temp = head;
            Node pre = null;
            int count = 0;
            while (temp != null)
            {
                if (count == m)
                {
                    preStart = pre;
                    start = temp;
                }
                else if (count == n)
                {
                    end = temp;
                    postEnd = temp.next;
                    break;
                }
                count++;
                pre = temp;
                temp = temp.next;
            }
            if (m != 0) { preStart.next = end; }
            else { head = end; }
            end.next = start;
            start.next = postEnd;
        }
    }

    public void BubbleSort()
    {
        if (head == null)
        {
            return;
        }
        int iterativeLength = length;
        while (iterativeLength > 0)
        {
            Node node = head;
            while (node != null)
            {
                if (node.next != null && node.value > node.next.value)
                {
                    int temp = node.next.value;
                    node.next.value = node.value;
                    node.value = temp;
                }
                node = node.next!;
            }
            iterativeLength--;
        }
    }

    void BubbleSort_Alt()
    {
        if (this.length < 2)
            return;

        Node sortedUntil = null;
        while (sortedUntil != this.head.next)
        {
            Node current = this.head;
            while (current.next != sortedUntil)
            {
                Node nextNode = current.next;
                if (current.value > nextNode.value)
                {
                    int temp = current.value;
                    current.value = nextNode.value;
                    nextNode.value = temp;
                }
                current = current.next;
            }
            sortedUntil = current;
        }
    }

    public void InsertionSort()
    {
        if (length < 2)
        {
            return;
        }
        Node sortedListHead = head;
        Node unsortedListHead = sortedListHead.next;

        while (unsortedListHead != null)
        {
            if (sortedListHead.value > unsortedListHead.value)
            {
                sortedListHead.next = unsortedListHead.next;
                Node searchPointer = head;
                Node prePointer = new Node(0);
                unsortedListHead.next = searchPointer;
                while (searchPointer != null && searchPointer.value < unsortedListHead.value)
                {
                    prePointer.next = searchPointer;
                    unsortedListHead.next = searchPointer.next;
                    searchPointer.next = unsortedListHead;
                    prePointer = searchPointer;
                    searchPointer = unsortedListHead.next;
                }
                if (searchPointer == head)
                {
                    head = unsortedListHead;
                }
                unsortedListHead = sortedListHead.next;
            }
            else
            {
                sortedListHead = unsortedListHead;
                unsortedListHead = unsortedListHead.next;
            }
        }
    }

    public void InsertionSort_Alt()
    {
        if (length < 2)
        {
            return; // List is already sorted
        }

        Node sortedListHead = head;
        Node unsortedListHead = head.next;
        sortedListHead.next = null;

        while (unsortedListHead != null)
        {
            Node current = unsortedListHead;
            unsortedListHead = unsortedListHead.next;

            if (current.value < sortedListHead.value)
            {
                current.next = sortedListHead;
                sortedListHead = current;
            }
            else
            {
                Node searchPointer = sortedListHead;
                while (searchPointer.next != null && current.value > searchPointer.next.value)
                {
                    searchPointer = searchPointer.next;
                }
                current.next = searchPointer.next;
                searchPointer.next = current;
            }
        }

        head = sortedListHead;
        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        tail = temp;
    }

    public void Merge(LinkedList otherList)
    {
        Node otherHead = otherList.getHead();
        Node dummy = new Node(0);
        Node current = dummy;
        Node temp1 = head;
        Node temp2 = otherHead;

        while (temp1 != null && temp2 != null)
        {
            if (temp1.value < temp2.value)
            {
                current.next = new Node(temp1.value);
                current = current.next;
                temp1 = temp1.next;
            }
            else
            {
                current.next = new Node(temp2.value);
                current = current.next;
                temp2 = temp2.next;
            }
        }
        while (temp1 != null)
        {
            current.next = new Node(temp1.value);
            current = current.next;
            temp1 = temp1.next;
        }
        while (temp2 != null)
        {
            current.next = new Node(temp2.value);
            current = current.next;
            temp2 = temp2.next;
        }

        head = dummy.next;
        tail = current;
    }
}