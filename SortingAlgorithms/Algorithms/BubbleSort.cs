using System;

namespace SortingAlgorithms.Algorithms
{
    internal class BubbleSort<T> where T : IComparable
    {
        internal T[] ReturnSorted_ASC(T[] arrayIntegers)
        {
            // If "numbers" == null --> initialize a new empty array to avoid the NullReferenceException
            T[] numbers = arrayIntegers ?? new T[] {};

            // Actual sorting (ascending order)
            int counter = numbers.Length;
            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter - 1; j++)
                {
                    if (numbers[j].CompareTo(numbers[j + 1]) >= 0)
                    {
                        Swap(ref numbers[j], ref numbers[j + 1]);
                    }
                }
                counter--;
            }

            return numbers;
        }

        internal T[] ReturnSorted_DESC(T[] arrayIntegers)
        {
            // If "numbers" == null --> initialize a new empty array to avoid the NullReferenceException
            T[] numbers = arrayIntegers ?? new T[] { };

            // Actual sorting (descending order)
            int counter = numbers.Length;
            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter - 1; j++)
                {
                    if (numbers[j].CompareTo(numbers[j + 1]) <= 0)
                    {
                        Swap(ref numbers[j], ref numbers[j + 1]);
                    }
                }
                counter--;
            }

            return numbers;
        }

        private static void Swap(ref T firstNumber, ref T secondnumber)
        {
            T tempNumber = firstNumber;
            firstNumber = secondnumber;
            secondnumber = tempNumber;
        }
    }
}
