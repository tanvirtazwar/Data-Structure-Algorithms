namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        LinkedList myLinkedList = new LinkedList(4);
        myLinkedList.append(2);
        myLinkedList.append(6);
        myLinkedList.append(5);
        myLinkedList.append(1);
        myLinkedList.append(3);


        Console.WriteLine("\nLinked List:");
        myLinkedList.printList();

        myLinkedList.InsertionSort();
        Console.WriteLine("\nLinked List:");
        myLinkedList.printList();
    }
}
