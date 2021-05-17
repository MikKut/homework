using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class QuickSortGenericStyle<T> where T : IComparable<T>
    {
        static void Swap(ref T x, ref T y)
        {
            T t = x;
            x = y;
            y = t;
        }
        static int Partition(T[] array, int minIndex, int maxIndex) 
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].CompareTo( array[maxIndex])<0)
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        static T[] QuickSort(T[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            int pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
    }
}
