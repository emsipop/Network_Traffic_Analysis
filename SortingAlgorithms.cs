using System;
using System.Collections.Generic;
using System.Text;

namespace Network_Traffic_Analysis
{
    class SortingAlgorithms
    {
        public static int inCounter = 0;
        public static int outCounter = 0;
        //RADIX SORT ALGORITHM
        public static void Radix_Sort(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                outCounter++;
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                    inCounter++;
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
        }

        // HEAP SORT ALGORITHM
        public static void Heap_Sort(int[] heap)
        {
            int heapSize = heap.Length;
            int i;

            for (i = (heapSize - 1) / 2; i >= 0; i--)
            {
                Max_Heapify(heap, heapSize, i);
            }

            for (i = heap.Length - 1; i > 0; i--)
            {
                int temp = heap[i];
                heap[i] = heap[0];
                heap[0] = temp;

                heapSize--;
                Max_Heapify(heap, heapSize, 0);
            }
        }
        private static void Max_Heapify(int[] Heap, int Heapsize, int Index)
        {
            inCounter++;
            int Left = (Index + 1) * 2 - 1;
            int Right = (Index + 1) * 2;
            int largest = 0;

            if (Left < Heapsize && Heap[Left] > Heap[Index])
            {
                largest = Left;
            }
            else
            {
                largest = Index;
            }

            if (Right < Heapsize && Heap[Right] > Heap[largest])
            {
                largest = Right;
            }

            if (largest != Index)
            {
                int temp = Heap[Index];
                Heap[Index] = Heap[largest];
                Heap[largest] = temp;
                Max_Heapify(Heap, Heapsize, largest);
            }
        }

        // MERGE SORT ALGORITHM
        public static void Merge(int[] data, int[] temp, int low, int middle, int high)
        {
            int ri = low;
            int ti = low;
            int di = middle;
            while (ti < middle && di <= high)
            {
                if (data[di] < temp[ti])
                {
                    data[ri++] = data[di++];
                }
                else
                {
                    data[ri++] = temp[ti++];
                }
                outCounter++;
            }
            while (ti < middle)
            {
                data[ri++] = temp[ti++];
                outCounter++;
            }
        }
        public static void MergeSortRecursive(int[] data, int[] temp, int low, int high)
        {
            int n = high - low + 1;
            int middle = low + n / 2;
            int i;

            if (n < 2) return;

            for (i = low; i < middle; i++)
            {
                temp[i] = data[i];
                inCounter++;
            }

            MergeSortRecursive(temp, data, low, middle - 1);
            MergeSortRecursive(data, temp, middle, high);
            Merge(data, temp, low, middle, high);
        }
        public static void Merge_Sort(int[] data)
        {
            int n = data.Length;
            int[] temp = new int[n];
            MergeSortRecursive(data, temp, 0, n - 1);
        }

        // QUICK SORT ALGORITHM
        public static void Quick_Sort(int[] data)
        {
            Quickly_Sort(data, 0, data.Length - 1);
        }
        public static void Quickly_Sort(int[] data, int left, int right)
        {
            int i, j;
            int pivot, temp;

            i = left;
            j = right;
            pivot = data[(left + right) / 2];

            do
            {
                while ((data[i] < pivot) && (i < right))
                {
                    i++;
                    inCounter++;
                }
                while ((pivot < data[j]) && (j > left))
                {
                    j--;
                    inCounter++;
                }

                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
                outCounter++;
            } while (i <= j);

            if (left < j) Quickly_Sort(data, left, j);
            if (i < right) Quickly_Sort(data, i, right);
        }
    }
}
