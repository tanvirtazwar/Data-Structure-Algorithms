namespace Dynamic_Programming
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int n = 10;

            //Console.WriteLine(Fib_No_Memo.fib(n));
            //Console.WriteLine(Fib_No_Memo.counter);
            //Console.WriteLine("\n");

            //Console.WriteLine(Fib_With_Memo.fib(n));
            //Console.WriteLine(Fib_With_Memo.counter);
            //Console.WriteLine("\n");

            //Console.WriteLine(Fib_Bottom_Up.fib(n));
            //Console.WriteLine(Fib_Bottom_Up.counter);
            //Console.WriteLine("\n");

            //int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //int val = 1;
            //int newLength1 = removeElement(nums, val);
            //foreach (int i in nums)
            //{
            //    Console.Write($"{i}  ");
            //}
            //Console.WriteLine("\n");

            //int[] myList1 = { 5, 3, 8, 1, 6, 9 };
            //int[] result1 = findMaxMin(myList1);
            //foreach (int i in result1)
            //{
            //    Console.Write($"{i}  ");
            //}
            //Console.WriteLine("\n");

            //string[] stringList1 = { "apple", "banana", "kiwi", "pear" };
            //string longest1 = findLongestString(stringList1);
            //Console.WriteLine(longest1);
            //Console.WriteLine("\n");

            //int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //int length = removeDuplicates(nums1);
            //Console.WriteLine(length);

            //foreach (int i in nums1)
            //{
            //    Console.Write($"{i}  ");
            //}

            int[] num2 = { 1, 2, 3, 4, 5, 6 };
            rotate_Alt(num2, 4);
            foreach (int i in num2)
            {
                Console.WriteLine(i);
            }

        }

        public static int removeDuplicates(int[] nums)
        {
            int length = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = nums[i];
                int count = i + 1;
                for (int j = count; j < nums.Length; j++)
                {
                    if (temp != nums[j])
                    {
                        nums[count] = nums[j];
                        count++;
                    }
                }

                if (count == i + 1)
                {
                    length = count;
                    break;
                }
            }

            return length;
        }

        public static int removeElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        public static int[] findMaxMin(int[] myList)
        {
            int[] results = new int[2];
            int highest = myList[0];
            int lowest = myList[0];

            for (int i = 1; i < myList.Length; i++)
            {
                if (myList[i] > highest)
                {
                    highest = myList[i];
                }
                else if (myList[i] < lowest)
                {
                    lowest = myList[i];
                }
            }
            results[0] = highest;
            results[1] = lowest;

            return results;
        }

        public static string findLongestString(string[] stringList)
        {
            string txt = "";
            foreach (var s in stringList)
            {
                if (s.Length > txt.Length)
                {
                    txt = s;
                }
            }

            return txt;
        }

        public static int maxProfit(int[] prices)
        {
            if (prices.Length < 2)
            {
                return 0;
            }
            int lowest = prices[0];
            int tempLowest = lowest;
            int highest = prices[1];
            for (int i = 1; i < prices.Length; i++)
            {
                if ((prices[i] - prices[i - 1]) > 0)
                {
                    if (highest <= prices[i])
                    {
                        highest = prices[i];
                        if (tempLowest > prices[i - 1])
                        {
                            lowest = prices[i - 1];
                        }
                        else
                        {
                            lowest = tempLowest;
                        }
                    }
                    if (lowest > prices[i - 1])
                    {
                        tempLowest = prices[i - 1];
                    }
                }
            }
            return Math.Max(highest - lowest, 0);
        }

        public static int maxProfit_Alt(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            foreach(int price in prices)
            {
                minPrice = Math.Min(minPrice, price);
                int profit = price - minPrice;
                maxProfit = Math.Max(maxProfit, profit);
            }

            return maxProfit;
        }


        public static void rotate(int[] nums, int k)
        {
            if (nums.Length < 2)
            {
                return;
            }

            if (nums.Length % k != 0)
            {
                int iteration = 0;
                int initialIndex = 0;
                int temp1 = nums[initialIndex];
                while (iteration < nums.Length)
                {
                    int destinationIndex = ((initialIndex + k) % (nums.Length));
                    int temp2 = nums[destinationIndex];
                    nums[destinationIndex] = temp1;
                    temp1 = temp2;
                    initialIndex = destinationIndex;
                    iteration++;
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    int iteration = 0;
                    int initialIndex = i;
                    int temp1 = nums[initialIndex];
                    while (iteration < ((nums.Length) / k))
                    {
                        int destinationIndex = ((initialIndex + k) % (nums.Length));
                        int temp2 = nums[destinationIndex];
                        nums[destinationIndex] = temp1;
                        temp1 = temp2;
                        initialIndex = destinationIndex;
                        iteration++;
                    }
                }
            }
        }

        public static void rotate_Alt(int[] nums, int k)
        {
            if (nums.Length < 2)
            {
                return;
            }
            if (k == 0)
            {
                return;
            }
            int i = 0;
            while (i < k)
            {
                int temp1 = nums[0];
                for (int j = 1; j <= nums.Length; j++)
                {
                    int temp2 = nums[j % (nums.Length)];
                    nums[j % (nums.Length)] = temp1;
                    temp1 = temp2;
                }
                i++;
            }
        }

        public static void rotate_Alt2(int[] nums, int k)
        {
            k = k % nums.Length;

            // Reverse the first part
            for (int start = 0, end = nums.Length - k - 1; start < end; start++, end--)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
            }

            // Reverse the second part
            for (int start = nums.Length - k, end = nums.Length - 1; start < end; start++, end--)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
            }

            // Reverse the whole array
            for (int start = 0, end = nums.Length - 1; start < end; start++, end--)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
            }
        }

        public static int maxSubarray(int[] nums)
        {
            if(nums.Length == 0)
            {
                return 0;
            }
            int sum = 0;
            int maxSum = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
                int temp = sum;
                for (int j = 0; j <= i; j++)
                {
                    if (temp > maxSum)
                    {
                        maxSum = temp;
                    }
                    temp = temp - nums[j];
                }
            }

            return maxSum;
        }
    }

    public class Fib_No_Memo
    {
        public static int counter = 0;

        public static int fib(int n)
        {
            counter++;

            if (n == 0 || n == 1)
            {
                return n;
            }
            return fib(n - 1) + fib(n - 2);
        }
    }

    public class Fib_With_Memo
    {
        public static Dictionary<int, int> memo = new Dictionary<int, int>();
        public static int counter = 0;

        public static int fib(int n)
        {
            counter++;

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            if (n == 0 || n == 1)
            {
                return n;
            }

            memo[n] = fib(n - 1) + fib(n - 2);

            return memo[n];
        }
    }

    public class Fib_Bottom_Up
    {
        public static int counter = 0;

        public static int fib(int n)
        {
            int[] fibList = new int[n + 1];
            fibList[0] = 0;
            fibList[1] = 1;

            for (int index = 2; index <= n; index++)
            {
                counter++;
                fibList[index] = fibList[index - 1] + fibList[index - 2];
            }
            return fibList[n];
        }
    }
}
