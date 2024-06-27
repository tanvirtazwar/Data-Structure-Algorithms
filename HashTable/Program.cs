using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            TestLongestConsecutiveSequence("Consecutive Integers", [1, 2, 3, 4, 5], 5);
            TestLongestConsecutiveSequence("No Sequence", [1, 3, 5, 7, 9], 1);
            TestLongestConsecutiveSequence("Duplicates", [1, 2, 2, 3, 4], 4);
            TestLongestConsecutiveSequence("Negative Numbers", [1, 0, -1, -2, -3], 5);
            TestLongestConsecutiveSequence("Empty Array", [], 0);
            TestLongestConsecutiveSequence("Multiple Sequences", [1, 2, 3, 10, 11, 12, 13], 4);
            TestLongestConsecutiveSequence("Unordered Elements", [5, 1, 3, 4, 2], 5);
            TestLongestConsecutiveSequence("Single Element", [1], 1);
            TestLongestConsecutiveSequence("All Identical Elements", [2, 2, 2, 2, 2], 1);

            int[] array1 = [3, 3, 4, 5];
            int[] array2 = [2, 4, 5];

            Console.WriteLine(ItemInCommon(array1, array2));

            Console.WriteLine(FirstNonRepeatingChar("leetcode"));
            Console.WriteLine(FirstNonRepeatingChar("hello"));
            Console.WriteLine(FirstNonRepeatingChar("aabbcc"));

            Console.WriteLine("1st set:");
            Console.WriteLine(GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]));

            Console.WriteLine("\n2nd set:");
            Console.WriteLine(GroupAnagrams(["abc", "cba", "bac", "foo", "bar"]));

            Console.WriteLine("\n3rd set:");
            Console.WriteLine(GroupAnagrams(["listen", "silent", "triangle", "integral", "garden", "ranged"]));


        }

        public static void TestLongestConsecutiveSequence(string title, int[] nums, int expected)
        {
            Console.WriteLine("Test: " + title);
            Console.WriteLine("Testing array: ");
            foreach (int num in nums)
            {
                Console.WriteLine(num + " ");
            }
            Console.WriteLine();

            int result = LongestConsecutiveSequence(nums);
            Console.WriteLine("Expected longest streak: " + expected);
            Console.WriteLine("Actual longest streak: " + result);

            if (result == expected)
            {
                Console.WriteLine("PASS\n");
            }
            else
            {
                Console.WriteLine("FAIL\n");
            }
        }

        public static int LongestConsecutiveSequence(int[] nums)
        {
            HashSet<int> numsSet = [.. nums];
            int longestStreak = 0;
            foreach (int num in numsSet)
            {
                int currentStreak = 1;
                if (!numsSet.Contains(num - 1))
                {
                    int currentNum = num;
                    while (numsSet.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentStreak++;
                    }
                }
                if (currentStreak >= longestStreak)
                {
                    longestStreak = currentStreak;
                }
            }
            return longestStreak;
        }

        public static int[] FindIntersectionValues(int[] nums1, int[] nums2)
        {
            HashSet<int> numsSet1 = [.. nums1];
            HashSet<int> numsSet2 = [.. nums2];
            int occurrence1 = 0;
            int occurrence2 = 0;
            foreach (int num in nums1)
            {
                if (numsSet2.Contains(num))
                {
                    occurrence1++;
                }
            }
            foreach (int num in nums2)
            {
                if (numsSet1.Contains(num))
                {
                    occurrence2++;
                }
            }
            return [occurrence1, occurrence2];
        }

        public static bool ItemInCommon(int[] array1, int[] array2)
        {
            Dictionary<int, bool> itemMap = [];

            foreach (int i in array1)
            {
                if (!itemMap.ContainsKey(i))
                {
                    itemMap.Add(i, true);
                }
            }

            foreach (int j in array2)
            {
                if (itemMap.ContainsKey(j)) return true;
            }

            return false;
        }

        public static int[] Twosum(int[] nums, int target)
        {
            Dictionary<int, int> numMap = [];
            int[] sum = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                int complement = target - num;

                if (numMap.ContainsKey(complement))
                {
                    sum = [numMap[complement], i];
                    break;
                }
                numMap.TryAdd(num, i);
            }

            return sum;
        }

        public static int[] SubarraySum(int[] nums, int target)
        {
            Dictionary<int, int> numCounts = [];
            int sum1 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum1 += nums[i];
                numCounts.TryAdd(sum1, i);
            }
            int sum2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (numCounts.ContainsKey(target + sum2))
                {
                    return [i, numCounts[target + sum2]];
                }
                sum2 += nums[i];
            }
            return [];
        }

        public static List<int> FindDuplicates(int[] nums)
        {
            Dictionary<int, bool> myHashMap = [];
            List<int> duplicates = [];
            foreach (int i in nums)
            {
                if (!myHashMap.TryGetValue(i, out bool value))
                {
                    myHashMap.Add(i, true);
                }
                else if (value == true)
                {
                    myHashMap[i] = false;
                    duplicates.Add(i);
                }
            }
            return duplicates;
        }

        public static int FirstNonRepeatingChar(string s)
        {
            Dictionary<char, List<int>> charMap = [];
            char[] inputChars = s.ToCharArray();
            for (int i = 0; i < inputChars.Length; i++)
            {
                if (!charMap.TryGetValue(inputChars[i], out List<int>? value))
                {
                    List<int> tmp = [i];
                    charMap.Add(inputChars[i], tmp);
                }
                else
                {
                    List<int> tmp = value;
                    tmp.Add(i);
                    charMap[inputChars[i]] = tmp;
                }
            }
            foreach (KeyValuePair<char, List<int>> kvp in charMap)
            {
                if (kvp.Value.Count == 1)
                {
                    return kvp.Value[0];
                }
            }
            return -1;
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> anagramsMap = [];
            foreach(string str in strs)
            {
                char[] charArray = str.ToCharArray();
                Array.Sort(charArray);
                string newStr = new(charArray);
                if (!anagramsMap.TryGetValue(newStr, out IList<string>? value))
                {
                    IList<string> list = [str];
                    anagramsMap.Add(newStr, list);
                }
                else
                {
                    IList<string> list = value;
                    list.Add(str);
                    anagramsMap[newStr] = list;
                }
            }
            IList<IList<string>> stringList = [];
            foreach (KeyValuePair<string, IList<string>> kvp in anagramsMap)
            {
                stringList.Add(kvp.Value);
            }
            return stringList;
        }
    }
}
