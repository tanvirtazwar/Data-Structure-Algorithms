using System.Reflection;

namespace Basic_Sorts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 4, 2, 6, 5, 1, 3 };

            InsertionSort(myArray);

            foreach (int i in myArray)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n");

            /*
                EXPECTED OUTPUT:
                ----------------
                [1, 2, 3, 4, 5, 6]

             */

            int[] array1 = { 2, 4, 5, 6 };
            int[] array2 = { 2, 4, 5, 6 };
            int[] array3 = Merge(array1, array2);

            foreach (int i in array3)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            int[] originalArray = { 4, 6, -8, -7, 1, 4, 2, 1 };

            int[] sortedArray = MergeSort(originalArray);

            foreach(int i in sortedArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            int[] myArray2 = { 4, 6, 1, 7, 3, 5, 2 };
            Pivot(myArray2, 0, 6);
            foreach (int i in myArray2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            int[] myArray4 = { 4, -8, -7, 1, -3, 4, 2, -1 };
            QuickSort(myArray4);
            foreach (int i in myArray4)
            {
                Console.WriteLine(i);
            }
        }

        public static void BubbleSort(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int insertIndex = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[j] > array[insertIndex])
                    {
                        int temp = array[j];
                        array[j] = array[insertIndex];
                        array[insertIndex] = temp;
                        insertIndex = j;
                    }
                }
            }
        }

        public static void InsertionSort_Alt(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j > -1 && temp < array[j])
                {
                    array[j + 1] = array[j];
                    array[j] = temp;
                    j--;
                }
            }
        }

        public static int[] Merge(int[] array1, int[] array2)
        {
            int[] mergedArray = new int[(array1.Length + array2.Length)];
            int index = 0;
            int i = 0;
            int j = 0;
            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] < array2[j])
                {
                    mergedArray[index] = array1[i];
                    index++;
                    i++;
                }
                else
                {
                    mergedArray[index] = array2[j];
                    index++;
                    j++;
                }
            }
            while (i < array1.Length)
            {
                mergedArray[index] = array1[i];
                index++;
                i++;
            }
            while (j < array2.Length)
            {
                mergedArray[index] = array2[j];
                index++;
                j++;
            }
            return mergedArray;
        }

        public static int[] MergeSort(int[] array)
        {
            if(array.Length < 2)
            {
                return array;
            }

            int midIndex = array.Length / 2;

            int[] leftArray = new int[midIndex];
            Array.Copy(array, 0, leftArray, 0, midIndex);
            int[] leftSortedArray = MergeSort(leftArray);

            int[] rightArray = new int[array.Length - midIndex];
            Array.Copy(array, midIndex, rightArray, 0, array.Length - midIndex);
            int[] rightSortedArray = MergeSort(rightArray);

            return Merge(leftSortedArray, rightSortedArray);
        }

        private static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        private static int Pivot(int[] array, int pivotIndex, int endIndex)
        {
            int swapIndex = pivotIndex;

            for(int i = pivotIndex + 1; i <= endIndex; i++)
            {
                if (array[pivotIndex] > array[i])
                {
                    swapIndex++;
                    Swap(array, i, swapIndex);
                }
            }

            Swap(array, pivotIndex, swapIndex);
            return swapIndex;
        }

        private static void QuickSortHelper(int[] array, int left, int right)
        {
            if(left < right)
            {
                int pivotIndex = Pivot(array, left, right);
                QuickSortHelper(array, left, pivotIndex - 1);
                QuickSortHelper(array, pivotIndex + 1, right);
            }
        }

        public static void QuickSort(int[] array)
        {
            QuickSortHelper(array, 0, array.Length - 1);
        }
    }
}
