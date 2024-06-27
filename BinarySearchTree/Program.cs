using System.Collections.Specialized;

namespace BinarySearchTree
{
    public class Program
    {
        static void Main(string[] args)
        {

            BinarySearchTree myBST = new BinarySearchTree();

            myBST.insert(47);
            myBST.insert(21);
            myBST.insert(76);
            myBST.insert(18);
            myBST.insert(27);
            myBST.insert(52);
            myBST.insert(82);

            myBST.printTree();
            foreach (var result in myBST.BFS())
            {
                Console.WriteLine($"BFS : {result}");
            }
            foreach (var result in myBST.DFSPreOrder())
            {
                Console.WriteLine($"DFS Pre Order :  {result}");
            }
            foreach (var result in myBST.DFSPostOrder())
            {
                Console.WriteLine($"DFS Post Order :  {result}");
            }
            foreach (var result in myBST.DFSInOrder())
            {
                Console.WriteLine($"DFS In Order :  {result}");
            }

            Console.WriteLine("\n");
            Console.WriteLine("BST Contains 52:");
            Console.WriteLine(myBST.rContains(52));

            Console.WriteLine("\n");
            Console.WriteLine("2 th smallest number :");
            Console.WriteLine(myBST.kthSmallest_Alt(2));

            myBST.remove(76);

            Console.WriteLine("\n");
            Console.WriteLine("BST Contains 52:");
            Console.WriteLine(myBST.rContains(52));

            Console.WriteLine("\n");
            myBST.printTree();

            myBST.rInsert(0);
            myBST.rInsert(20);
            myBST.rInsert(100);
            myBST.rInsert(85);
            myBST.rInsert(72);
            myBST.rInsert(50);
            myBST.rInsert(101);
            myBST.rInsert(25);

            Console.WriteLine("\n");
            myBST.printTree();
            myBST.deleteNode(82);
            myBST.deleteNode(21);
            Console.WriteLine("\n");
            myBST.printTree();

            myBST.invert();
            Console.WriteLine("\n");
            myBST.printTree();

            // Test: Convert an empty array
            Console.WriteLine("\n----- Test: Convert Empty Array -----\n");
            int[] num1 = { };
            checkBalancedAndCorrectTraversal(num1, num1.ToList());

            // Test: Convert an array with one element
            Console.WriteLine("\n----- Test: Convert Single Element Array -----\n");
            int[] num2 = { 10 };
            checkBalancedAndCorrectTraversal(num2, num2.ToList());

            // Test: Convert a sorted array with odd number of elements
            Console.WriteLine("\n----- Test: Convert Sorted Array with Odd Number of Elements -----\n");
            int[] num3 = { 1, 2, 3, 4, 5 };
            checkBalancedAndCorrectTraversal(num3, num3.ToList());

            // Test: Convert a sorted array with even number of elements
            Console.WriteLine("\n----- Test: Convert Sorted Array with Even Number of Elements -----\n");
            int[] num4 = { 1, 2, 3, 4, 5, 6 };
            checkBalancedAndCorrectTraversal(num4, num4.ToList());

            // Test: Convert a large sorted array
            Console.WriteLine("\n----- Test: Convert Large Sorted Array -----\n");
            int[] num5 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            checkBalancedAndCorrectTraversal(num5, num5.ToList());

        }

        public static void checkBalancedAndCorrectTraversal(int[] nums, List<int> expectedTraversal)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.sortedArrayToBST(nums);
            bool isBalanced = bst.isBalanced();
            List<int> inorder = bst.inorderTraversal();
            Console.WriteLine("Is balanced: " + isBalanced);
            Console.WriteLine("Inorder traversal: " + inorder);
            Console.WriteLine("Expected traversal: " + expectedTraversal);
            if (isBalanced && inorder.Equals(expectedTraversal))
            {
                Console.WriteLine("PASS: Tree is balanced and inorder traversal is correct.\n");
            }
            else
            {
                Console.WriteLine("FAIL: Tree is either not balanced or inorder traversal is incorrect.\n");
            }
        }

    }

    public class BinarySearchTree
    {

        private Node root;

        public class Node(int value)
        {
            public int value = value;
            public Node left;
            public Node right;
        }

        private void printTree(Node node, int value)
        {
            Node temp = node;
            value = value + 1;
            if (temp.left != null)
            {
                printTree(temp.left, value);
            }

            Console.WriteLine($"Layer - {value}__{temp.value}");

            if (temp.right != null)
            {
                printTree(temp.right, value);
            }
        }

        public void printTree()
        {
            printTree(root, 0);
        }

        public bool insert(int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
                return true;
            }
            Node temp = root;
            while (true)
            {
                if (newNode.value == temp.value) return false;
                if (newNode.value < temp.value)
                {
                    if (temp.left == null)
                    {
                        temp.left = newNode;
                        return true;
                    }
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                    {
                        temp.right = newNode;
                        return true;
                    }
                    temp = temp.right;
                }
            }
        }

        public bool contains(int value)
        {
            if (root == null) return false;
            Node temp = root;
            while (temp != null)
            {
                if (value < temp.value)
                {
                    temp = temp.left;
                }
                else if (value > temp.value)
                {
                    temp = temp.right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public bool remove(int value)
        {
            Node temp = root;
            Node pre = temp;
            Node removedNode = null!;
            while (temp != null)
            {
                if (value < temp.value)
                {
                    pre = temp;
                    if (temp.left != null)
                    {
                        temp = temp.left;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (value > temp.value)
                {
                    pre = temp;
                    if (temp.right != null)
                    {
                        temp = temp.right;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    removedNode = temp;
                    if (temp.right != null)
                    {
                        pre = temp;
                        temp = temp.right;
                    }
                    else if (temp.left != null)
                    {
                        pre = temp;
                        temp = temp.left;
                    }
                }
            }
            if (temp == null) { return false; }

            removedNode.value = temp.value;

            if (pre.right == temp)
            {
                pre.right = null!;
            }
            else if (pre.left == temp)
            {
                pre.left = null!;
            }
            return true;
        }

        private bool rContains(Node currentNode, int value)
        {
            if (currentNode == null) return false;

            if (currentNode.value == value) return true;

            if (value < currentNode.value)
            {
                return rContains(currentNode.left, value);
            }
            else
            {
                return rContains(currentNode.right, value);
            }
        }

        public bool rContains(int value)
        {
            return rContains(root, value);
        }

        private Node rInsert(Node currentNode, int value)
        {
            if (currentNode == null) return new Node(value);

            if (value < currentNode.value)
            {
                currentNode.left = rInsert(currentNode.left, value);
            }
            else if (value > currentNode.value)
            {
                currentNode.right = rInsert(currentNode.right, value);
            }
            return currentNode;
        }

        public void rInsert(int value)
        {
            if (root == null) root = new Node(value);
            rInsert(root, value);
        }

        private int minvalue(Node currentNode)
        {
            while (currentNode.left != null)
            {
                currentNode = currentNode.left;
            }
            return currentNode.value;
        }

        private Node deleteNode(Node currentNode, int value)
        {
            if (currentNode == null) return null!;

            if (value < currentNode.value)
            {
                currentNode.left = deleteNode(currentNode.left, value);
            }
            else if (value > currentNode.value)
            {
                currentNode.right = deleteNode(currentNode.right, value);
            }
            else
            {
                if (currentNode.left == null && currentNode.right == null)
                {
                    return null!;
                }
                else if (currentNode.left == null)
                {
                    currentNode = currentNode.right;
                }
                else if (currentNode.right == null)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    int subTreeMin = minvalue(currentNode.right);
                    currentNode.value = subTreeMin;
                    currentNode.right = deleteNode(currentNode.right, subTreeMin);
                }
            }

            return currentNode;
        }

        public void deleteNode(int value)
        {
            deleteNode(root, value);
        }




        // BST: Convert Sorted Array to Balanced BST ( ** Interview Question)
        public Node getRoot()
        {
            return root;
        }

        public List<int> inorderTraversal()
        {
            List<int> result = new List<int>();
            inorderHelper(this.root, result);
            return result;
        }

        private void inorderHelper(Node node, List<int> result)
        {
            if (node == null) return;
            inorderHelper(node.left, result);
            result.Add(node.value);
            inorderHelper(node.right, result);
        }

        public bool isBalanced()
        {
            return height(this.root) != -1;
        }

        private int height(Node node)
        {
            if (node == null) return 0;
            int leftHeight = height(node.left);
            if (leftHeight == -1) return -1;
            int rightHeight = height(node.right);
            if (rightHeight == -1) return -1;
            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;
            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public void sortedArrayToBST(int[] nums)
        {
            this.root = sortedArrayToBST(nums, 0, nums.Length - 1);
        }

        //   +===================================================+
        //   |             WRITE YOUR CODE HERE                  |
        //   | Description:                                      |
        //   | - Converts a sorted array into a height-balanced  |
        //   |   binary search tree (BST).                       |
        //   | - This method is private and used internally      |
        //   |   within the class.                               |
        //   | - It uses recursion to construct the BST.         |
        //   |                                                   |
        //   | Parameters:                                       |
        //   | - nums: Sorted array of integers.                 |
        //   | - left: Starting index for the current segment    |
        //   |   of the array.                                   |
        //   | - right: Ending index for the current segment of  |
        //   |   the array.                                      |
        //   |                                                   |
        //   | Return:                                           |
        //   | - The root node of the BST created from the       |
        //   |   sorted array segment.                           |
        //   |                                                   |
        //   | Tips:                                             |
        //   | - The middle element of the current segment is    |
        //   |   chosen as the root to ensure the BST is         |
        //   |   height-balanced.                                |
        //   | - The method recursively builds the left and right|
        //   |   subtrees by calling itself with adjusted left   |
        //   |   and right indices to work on sub-segments of    |
        //   |   the array.                                      |
        //   +===================================================+

        private Node sortedArrayToBST(int[] nums, int left, int right)
        {
            Node currentNode = null;
            int range = (right - left) + 1;
            int middle = left + (range / 2);
            if (range == 1)
            {
                currentNode = new Node(nums[middle]);
            }
            else if (range > 1)
            {
                currentNode = new Node(nums[middle]);
                currentNode.left = sortedArrayToBST(nums, left, (middle - 1));
                currentNode.right = sortedArrayToBST(nums, (middle + 1), right);
            }
            return currentNode;
        }



        // BST: Invert Binary Tree ( ** Interview Question)
        public void invert()
        {
            root = invertTree(root);
        }

        //   +===================================================+
        //   |              WRITE YOUR CODE HERE                 |
        //   | Description:                                      |
        //   | - Inverts a binary tree by swapping the left and  |
        //   |   right children of all nodes in the tree.        |
        //   | - This method is private and intended for internal|
        //   |   use within the class.                           |
        //   | - It operates recursively, visiting each node and |
        //   |   swapping its children.                          |
        //   |                                                   |
        //   | Parameters:                                       |
        //   | - node: The current node to process.              |
        //   |                                                   |
        //   | Return:                                           |
        //   | - The node after its subtree has been inverted.   |
        //   |                                                   |
        //   | Tips:                                             |
        //   | - The base case for the recursion is when the     |
        //   |   method encounters a null node.                  |
        //   | - A temporary node is used to facilitate the swap |
        //   |   of the left and right children.                 |
        //   +===================================================+

        private Node invertTree(Node node)
        {
            if (node == null)
            {
                return null;
            }

            Node temp = node.left;
            node.left = node.right;
            node.right = temp;

            invertTree(node.left);
            invertTree(node.right);

            return node;
        }

        public List<int> BFS()
        {
            Node currentNode = root;
            Queue<Node> queue = new Queue<Node>();
            List<int> results = new List<int>();
            if (currentNode != null)
            {
                queue.Enqueue(currentNode);
            }

            while (queue.Count() > 0)
            {
                currentNode = queue.Dequeue();
                if (currentNode != null)
                {
                    results.Add(currentNode.value);
                    queue.Enqueue(currentNode.left);
                    queue.Enqueue(currentNode.right);
                }
            }
            return results;
        }

        public List<int> DFSPreOrder()
        {
            List<int> results = new List<int>();
            return DFSPreOrder(root, results);
        }

        private List<int> DFSPreOrder(Node currentNode, List<int> results)
        {
            results.Add(currentNode.value);
            if (currentNode.left != null)
            {
                DFSPreOrder(currentNode.left, results);
            }
            if (currentNode.right != null)
            {
                DFSPreOrder(currentNode.right, results);
            }
            return results;
        }

        public List<int> DFSPostOrder()
        {
            List<int> results = [];
            return DFSPostOrder(root, results);
        }

        private List<int> DFSPostOrder(Node currentNode, List<int> results)
        {
            if (currentNode.left != null)
            {
                DFSPostOrder(currentNode.left, results);
            }
            if (currentNode.right != null)
            {
                DFSPostOrder(currentNode.right, results);
            }

            results.Add(currentNode.value);

            return results;
        }

        public List<int> DFSInOrder()
        {
            List<int> results = [];
            return DFSInOrder(root, results);
        }

        private List<int> DFSInOrder(Node currentNode, List<int> results)
        {
            if (currentNode.left != null)
            {
                DFSInOrder(currentNode.left, results);
            }

            results.Add(currentNode.value);

            if (currentNode.right != null)
            {
                DFSInOrder(currentNode.right, results);
            }

            return results;
        }

        //__________________________________________________________________________________________________________________

        //   +===================================================+
        //   |                  WRITE YOUR CODE HERE             |
        //   | Description:                                      |
        //   | - Checks if the binary tree is a valid Binary     |
        //   |   Search Tree (BST).                              |
        //   | - A BST is valid if all nodes follow the left <   |
        //   |   parent < right rule across the entire tree.     |
        //   | - Utilizes in-order traversal to collect node     |
        //   |   values and then checks if the list of values    |
        //   |   is in ascending order without duplicates.       |
        //   |                                                   |
        //   | Return:                                           |
        //   | - Returns true if the tree is a valid BST.        |
        //   | - Returns false otherwise.                        |
        //   |                                                   |
        //   | Tips:                                             |
        //   | - DFSInOrder() is assumed to be a method that     |
        //   |   performs an in-order traversal of the tree and  |
        //   |   returns an ArrayList of node values.            |
        //   | - A valid BST should have its in-order traversal  |
        //   |   result in a strictly ascending order list.      |
        //   +===================================================+

        public bool isValidBST()
        {
            List<int> results = DFSInOrder();
            if (results.Count == 1)
            {
                return true;
            }
            for (int i = 1; i < results.Count; i++)
            {
                if (!(results[i - 1] < results[i]))
                {
                    return false;
                }
            }
            return true;
        }

        //__________________________________________________________________________________________________________________
        //__________________________________________________________________________________________________________________
        //____________________________BST: Kth Smallest Node ( ** Interview Question)_______________________________________
        public int kthSmallest_Alt(int k)
        {
            Stack<Node> stack = new Stack<Node>();
            Node node = this.root;

            while (!(stack.Count == 0) || node != null)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                node = stack.Pop();
                k -= 1;
                if (k == 0)
                {
                    return node.value;
                }
                node = node.right;
            }
            throw new IndexOutOfRangeException("k is out of range (must be between 1 and the list's size)");
        }

        public int kthSmallest(int k)
        {
            List<int> results = new List<int>();
            results = DFSInOrder(root, results); 

            if (k < 1 || k > results.Count)
            {
                throw new IndexOutOfRangeException("k is out of range (must be between 1 and the list's size)");
            }

            return results[k - 1];
        }

        //__________________________________________________________________________________________________________________
    }

}
