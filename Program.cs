using System;
using System.IO;
using System.Collections.Generic;

namespace Network_Traffic_Analysis
{
    class Program
    {
        /* Method WhichArrays() returns an integer array depending on the network array chosen
           by user. */
        static int[] WhichArrays()
        {
            Console.WriteLine("What would you like to do?\n1. Analyse 1 array\n2. Merge 2 arrays");
            int arrayNum = int.Parse(Console.ReadLine());
            int[] intArr = new int[] { };

            /* If the user chooses to analyse 1 array they will be given the option of which array
               to select. The selected array is then converted into an integer array. 
               Otherwise, if the user chooses to merge two arrays the Merge() method is called. */
            if (arrayNum == 1)
            {
                string[] stringArr = File.ReadAllLines(SelectArray());
                intArr = Array.ConvertAll(stringArr, int.Parse);
            }
            else if (arrayNum == 2)
            {
                string[] stringArr = Merge();
                intArr = Array.ConvertAll(stringArr, int.Parse);
            }
            return intArr;
        }

        /* Method WhatValue() returns an integer depending on the value chosen by the user. */
        static int WhatValue()
        {
            Console.WriteLine("What number do you want to search for?");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        /* The corresponding file is called to be read in the WhichArrays() method */
        public static string SelectArray()
        {
            Console.WriteLine("\nWhich array would you like to use?\n");
            Console.WriteLine("256 data points");
            Console.WriteLine("1. Network 1\n2. Network 2\n3. Network 3\n");
            Console.WriteLine("2048 data points");
            Console.WriteLine("4. Network 1\n5. Network 2\n6. Network 3\n");

            int input = int.Parse(Console.ReadLine());
            string file = "InputFiles/";

            switch (input)
            {
                case 1:
                    file += "Net_1_256.txt";
                    break;
                case 2:
                    file += "Net_2_256.txt";
                    break;
                case 3:
                    file += "Net_3_256.txt";
                    break;
                case 4:
                    file += "Net_1_2048.txt";
                    break;
                case 5:
                    file += "Net_2_2048.txt";
                    break;
                case 6:
                    file += "Net_3_2048.txt";
                    break;
            }
            return file;
        }

        /* User selects which arrays they want to merge */
        public static string ArraysToMerge()
        {
            Console.WriteLine("Which arrays would you like to merge?\n");
            Console.WriteLine("256 data points");
            Console.WriteLine("1. Network 1 and Network 3\n");
            Console.WriteLine("2048 data points");
            Console.WriteLine("2. Network 1 and Network 3\n");

            int input = int.Parse(Console.ReadLine());
            string merge = "";

            switch (input)
            {
                case 1:
                    merge = "merge256";
                    break;
                case 2:
                    merge = "merge2048";
                    break;
            }
            return merge;
        }

        static string[] Merge()
        {
            string fileOne = "InputFiles/";
            string fileTwo = "InputFiles/";

            switch (ArraysToMerge())
            {
                case "merge256":
                    fileOne += "Net_1_256.txt";
                    fileTwo += "Net_3_256.txt";
                    break;
                case "merge2048":
                    fileOne += "Net_1_2048.txt";
                    fileTwo += "Net_3_2048.txt";
                    break;
            }
            string[] stringArrOne = File.ReadAllLines(fileOne);
            string[] stringArrTwo = File.ReadAllLines(fileTwo);
            var myList = new List<string>(); // temporary list to store values from files to merge
            myList.AddRange(stringArrOne);
            myList.AddRange(stringArrTwo);
            string[] arr = myList.ToArray();
            return arr;
        }

        /* Gives the user choice of sorting algorithms */
        static int SelectSort()
        {
            Console.WriteLine("\nWhich sorting algorithm would you like to use?");
            Console.WriteLine("1. Radix Sort");
            Console.WriteLine("2. Heap Sort");
            Console.WriteLine("3. Merge Sort");
            Console.WriteLine("4. Quick Sort");

            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        static int SelectSearch()
        {
            Console.WriteLine("Which searching algorithm would you like to use?");
            Console.WriteLine("1. Binary Search");
            Console.WriteLine("2. Interpolation Search");

            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        // Reverses the order of the sorted array given
        public static void DescendingOrder(int[] ascArray)
        {
            for (int i = 0; i < ascArray.Length / 2; i++)
            {
                int tmp = ascArray[i];
                ascArray[i] = ascArray[ascArray.Length - i - 1];
                ascArray[ascArray.Length - i - 1] = tmp;
            }
        }

        /* Displays every 10th value of the array if the 256 data points have been analysed.
           Displays every 50th value of the array if the 2048 data points have been analysed. */
        public static void nthValue(int[] array)
        {
            if (array.Length == 2048 || array.Length == 2048 + 2048)
            {
                Console.WriteLine("\nDisplaying every 50th value...");
                for (int index = 49; index < array.Length - 1; index += 50)
                {
                    Console.WriteLine(array[index]);
                }
            }
            else
            {
                Console.WriteLine("\nDisplaying every 10th value...");
                for (int index = 9; index < array.Length - 1; index += 10)
                {
                    Console.WriteLine(array[index]);
                }
            }
        }

        static void Main(string[] args)
        {
            // Integer array created from the string array chosen in WhichArrays() method
            int[] intArr = WhichArrays();

            /* The corresponding sorting algorithm is implemented depending on the sorting algorithm 
               chosen in the SelectSort() method.
               The integer array is passed in as an argument for the corresponding algorithm which sorts
               the array */
            switch (SelectSort())
            {
                case 1:
                    Console.WriteLine("Using Radix Sort");
                    SortingAlgorithms.Radix_Sort(intArr);
                    break;
                case 2:
                    Console.WriteLine("Using Heap Sort");
                    SortingAlgorithms.Heap_Sort(intArr);
                    break;
                case 3:
                    Console.WriteLine("Using Merge Sort");
                    SortingAlgorithms.Merge_Sort(intArr);
                    break;
                case 4:
                    Console.WriteLine("Using Quick Sort");
                    SortingAlgorithms.Quick_Sort(intArr);
                    break;
                default:
                    Console.WriteLine("Using Radix Sort by default");
                    SortingAlgorithms.Radix_Sort(intArr);
                    break;
            }

            Console.WriteLine("How would you like the array displayed?\n1. Ascending Order\n2. Descending Order");
            int order = int.Parse(Console.ReadLine());
            if (order == 2)
            {
                DescendingOrder(intArr);
            }

            nthValue(intArr);

            Console.WriteLine($"Inner sort count: {SortingAlgorithms.inCounter}");
            Console.WriteLine($"Outer sort count: {SortingAlgorithms.outCounter}");

            // Integer from the value inserted in WhatValue() method
            int value = WhatValue();

            /* The corresponding searching algorithm is implemented depending on the searching algorithm 
               chosen in the SelectSearch() method.
               The sorted array and value are passed in as arguments for the corresponding algorithm which searches
               for the location (index value) if it exists */

            if (order == 2)
            { 
                DescendingOrder(intArr); // the order is returned to ascending if displayed in descending to search
            }

            switch (SelectSearch())
            {
                case 1:
                    Console.WriteLine("Using Binary Search by default");
                    SearchingAlgorithms.Binary_Search(intArr, value);
                    break;
                case 2:
                    Console.WriteLine("Using Interpolation Search by default");
                    SearchingAlgorithms.Interpolation_Search(intArr, value);
                    break;
                default:
                    Console.WriteLine("Using Binary Search by default");
                    SearchingAlgorithms.Binary_Search(intArr, value);
                    break;
            }

            Console.WriteLine($"Search count: {SearchingAlgorithms.counter}");
        }
    }
}
