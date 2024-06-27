namespace DoublyLinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList myDLL = new DoublyLinkedList(1);
        myDLL.append(2);
        myDLL.append(3);
        myDLL.append(4);
        myDLL.append(5);

        Console.WriteLine("DLL before swapPairs():");
        myDLL.printList();

    }
}
