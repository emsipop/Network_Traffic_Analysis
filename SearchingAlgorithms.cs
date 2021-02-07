using System;
using System.Collections.Generic;
using System.Text;

namespace Network_Traffic_Analysis
{
    class SearchingAlgorithms
    {
        public static int counter = 0;
        // BINARY SEARCH ALGORITHM
        public static int Binary_Search(int[] x, int searchValue)
        {
            // Returns index(es) of searchValue in sorted array x, or -1 if not found
            int left = 0;
            int right = x.Length;
            return binarySearch(x, searchValue, left, right);
        }

        /* If value does not exist, calls findClosest() method to find the closest value and its location(s). */
        public static int binarySearch(int[] x, int searchValue, int left, int right)
        {
            counter++;
            if (right < left)
            {
                Console.WriteLine($"{searchValue} not found... closest value {findClosest(x, searchValue)} used instead {Binary_Search(x, findClosest(x, searchValue))}");
                return -1;
            }
            int mid = (left + right) >> 1;
            if (searchValue > x[mid])
            {
                return binarySearch(x, searchValue, mid + 1, right);
            }
            else if (searchValue < x[mid])
            {
                return binarySearch(x, searchValue, left, mid - 1);
            }
            else
            {
                getAllValues(x, searchValue, mid);
                return mid;
            }
        }

        // INTERPOLATION SEARCH ALGORITHM
        public static int Interpolation_Search(int[] x, int searchValue)
        {
            // Returns index(es) of searchValue in sorted input data
            // array x, or -1 if searchValue is not found
            int low = 0;
            int high = x.Length - 1;
            int mid;

            while (x[low] < searchValue && x[high] >= searchValue)
            {
                mid = low + ((searchValue - x[low]) * (high - low)) / (x[high] - x[low]);

                counter++;

                if (x[mid] < searchValue)
                    low = mid + 1;
                else if (x[mid] > searchValue)
                    high = mid - 1;
                else
                {
                    getAllValues(x, searchValue, mid);
                    return mid;
                }
            }

            if (x[low] == searchValue)
            {
                getAllValues(x, searchValue, low);
                return low;
            }
            else
            {
                Console.WriteLine($"{searchValue} not found... closest value {findClosest(x, searchValue)} used instead {Binary_Search(x, findClosest(x, searchValue))}");
                return -1; // Not found
            }
        }

        // FINDING NEAREST VALUE
        // Returns element closest 
        // to target in arr[] 
        public static int findClosest(int[] arr, int target)
        {
            int n = arr.Length;

            // Corner cases 
            if (target <= arr[0])
                return arr[0];
            if (target >= arr[n - 1])
                return arr[n - 1];

            // Doing binary search  
            int i = 0, j = n, mid = 0;
            while (i < j)
            {
                mid = (i + j) / 2;

                if (arr[mid] == target)
                    return arr[mid];

                /* If target is less  
                than array element, 
                then search in left */
                if (target < arr[mid])
                {

                    // If target is greater  
                    // than previous to mid,  
                    // return closest of two 
                    if (mid > 0 && target > arr[mid - 1])
                        return getClosest(arr[mid - 1],
                                     arr[mid], target);

                    /* Repeat for left half */
                    j = mid;
                }

                // If target is  
                // greater than mid 
                else
                {
                    if (mid < n - 1 && target < arr[mid + 1])
                        return getClosest(arr[mid],
                             arr[mid + 1], target);
                    i = mid + 1; // update i 
                }
            }

            // Only single element 
            // left after search 
            return arr[mid];
        }

        // Method to compare which one  
        // is the more close We find the  
        // closest by taking the difference 
        // between the target and both  
        // values. It assumes that val2 is 
        // greater than val1 and target 
        // lies between these two. 
        public static int getClosest(int val1, int val2, int target)
        {
            if (target - val1 >= val2 - target)
                return val2;
            else
                return val1;
        }

        /* Method to create an array of all index locations found for the input value. */
        public static void getAllValues(int[] array, int value, int startIndex)
        {
            int times = 0;
            int index = startIndex;
            List<int> indexList = new List<int>();
            while (value == array[index])
            {
                times++;
                indexList.Add(index);
                index--;
            }
            index = startIndex + 1;
            while (value == array[index])
            {
                times++;
                indexList.Add(index);
                index++;
            }
            int[] indexes = indexList.ToArray();
            Program.DescendingOrder(indexes);
            Console.WriteLine($"{value} was found {times} time(s) in the ascendingly sorted array at the following index location(s): ");
            foreach (var num in indexes)
            {
                Console.WriteLine(num);
            }
        }
    }
}
