using System;

namespace SortingAlgorithms.Algorithms
{
    /* ANNOTATION: To achieve a little higher time performance for sorting algorithms,
                   there's a need to reduce memory-costly IF conditionals, normally used
                   when switching between "ascending" and "descending" order inside of the
                   actual sorting algorithms, and their helper methods, even at cost of the
                   most basic "DRY Principle" (Don't Repeat Yourself) */

    internal class QuickSort<T> where T : IComparable
    {
        // Simultaneously, recursive sorting of the left and the right side of the pivot (ascending order)
        internal T[] ReturnSorted_ASC(T[] numbers, int start, int last)
        {
            if (start < last)
            {
                int partitionIndex = Partition_ASC(numbers, start, last);  // Index of the pivot

                ReturnSorted_ASC(numbers, start, partitionIndex - 1);  // Numbers on the left side of the pivot
                ReturnSorted_ASC(numbers, partitionIndex + 1, last);  // Numbers on the rifht side of the pivot
            }

            return numbers;
        }

        // Set pivot at the last element and compares it with smallest and greatest numbers (ascending order)
        private static int Partition_ASC(T[] numbers, int start, int last)
        {
            T pivot = numbers[last];

            int i = start - 1;

            for (int j = start; j <= last - 1; j++)
            {
                if (numbers[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(ref numbers[i], ref numbers[j]);
                }
            }
            Swap(ref numbers[i + 1], ref numbers[last]);

            return i + 1;
        }

        // Simultaneously, recursive sorting of the left and the right side of the pivot (descending order)
        internal T[] ReturnSorted_DESC(T[] numbers, int start, int last)
        {
            if (start < last)
            {
                int partitionIndex = Partition_DESC(numbers, start, last);  // Index of the pivot

                ReturnSorted_DESC(numbers, start, partitionIndex - 1);  // Numbers on the left side of the pivot
                ReturnSorted_DESC(numbers, partitionIndex + 1, last);  // Numbers on the rifht side of the pivot
            }

            return numbers;
        }

        // Set pivot at the last element and compares it with smallest and greatest numbers (descending order)
        private static int Partition_DESC(T[] numbers, int start, int last)
        {
            T pivot = numbers[last];

            int i = start - 1;

            for (int j = start; j <= last - 1; j++)
            {
                if (numbers[j].CompareTo(pivot) >= 0)
                {
                    i++;
                    Swap(ref numbers[i], ref numbers[j]);
                }
            }
            Swap(ref numbers[i + 1], ref numbers[last]);

            return i + 1;
        }

        // Replace two numbers in their original places
        private static void Swap(ref T firstNumber, ref T secondNumber)
        {
            T tempNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempNumber;
        }
    }
}
