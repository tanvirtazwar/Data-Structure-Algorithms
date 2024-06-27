namespace HashTable
{
    public class HashTable 
    {
        private readonly int size = 7;
        private readonly Node[] dataMap;

        public class Node(string key, int value)
        {
            public string key = key;
            public int value = value;
            public Node next;
        }

        public HashTable()
        {
            dataMap = new Node[size];
        }

        public void printTable()
        {
            for (int i = 0; i < dataMap.Length; i++)
            {
                Console.WriteLine(i + ":");
                Node temp = dataMap[i];
                while (temp != null)
                {
                    Console.WriteLine("   {" + temp.key + "= " + temp.value + "}");
                    temp = temp.next;
                }
            }
        }

        private int hash(string key)
        {
            int hash = 0;
            char[] keyChars = key.ToCharArray();
            for (int i = 0; i < keyChars.Length; i++)
            {
                int asciiValue = keyChars[i];
                hash = (hash + asciiValue * 23) % dataMap.Length;
            }
            return hash;
        }

        public void set(string key, int value)
        {
            int index = hash(key);
            Node newNode = new Node(key, value);
            if (dataMap[index] == null)
            {
                dataMap[index] = newNode;
            }
            else
            {
                Node temp = dataMap[index];
                if (temp.key == key)
                {
                    temp.value += value;
                    return;
                }
                while (temp.next != null)
                {
                    temp = temp.next;
                    if (temp.key == key)
                    {
                        temp.value += value;
                        return;
                    }
                }
                temp.next = newNode;
            }
        }

        public int get(string key)
        {
            int index = hash(key);
            Node temp = dataMap[index];
            while (temp != null)
            {
                if (temp.key == key) return temp.value;
                temp = temp.next;
            }
            return 0;
        }

        public List<string> keys()
        {
            List<string> allKeys = [];
            for (int i = 0; i < dataMap.Length; i++)
            {
                Node temp = dataMap[i];
                while (temp != null)
                {
                    allKeys.Add(temp.key);
                    temp = temp.next;
                }
            }
            return allKeys;
        }

    }
}
