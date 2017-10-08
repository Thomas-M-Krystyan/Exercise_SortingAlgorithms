using System;
using SortingAlgorithms.Algorithms;
using SortingAlgorithms.Performance;
using static SortingAlgorithms.Utilities.UserInterfaceMessages;

namespace SortingAlgorithms.Controllers
{
    internal static class SortingController<T> where T : IComparable
    {
        // Flow of the switching between already implemented sorting algorithms
        internal static T[] ChooseMethod(T[] numbers, string algorithmName, string sortingOrder)
        {
            T[] sortedNumbers = new T[] {};

            BubbleSort<T> bubbleSort = new BubbleSort<T>();
            QuickSort<T> quickSort = new QuickSort<T>();

            Console.WriteLine(WaitingMessage);

            if (algorithmName.ToLower().Equals("bubble"))
            {
                if (sortingOrder.ToLower().Equals("asc"))
                {
                    using (ThreadPerformance.Measure())
                    {
                        sortedNumbers = bubbleSort.ReturnSorted_ASC(numbers);
                    }
                }
                else if (sortingOrder.ToLower().Equals("desc"))
                {
                    using (ThreadPerformance.Measure())
                    {
                        sortedNumbers = bubbleSort.ReturnSorted_DESC(numbers);
                    }
                }
                else
                {
                    Console.WriteLine(ErrorSortingOrder);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            else if (algorithmName.ToLower().Equals("quick"))
            {
                int start = 0;
                int last = numbers.Length - 1;

                if (sortingOrder.ToLower().Equals("asc"))
                {
                    using (ThreadPerformance.Measure())
                    {
                        sortedNumbers = quickSort.ReturnSorted_ASC(numbers, start, last);
                    }
                }
                else if (sortingOrder.ToLower().Equals("desc"))
                {
                    using (ThreadPerformance.Measure())
                    {
                        sortedNumbers = quickSort.ReturnSorted_DESC(numbers, start, last);
                    }
                }
                else
                {
                    Console.WriteLine(ErrorSortingOrder);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine(ErrorSortingMethod);
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine(WaitingForPressKey);
            Console.ReadKey();

            DisplayResult(sortedNumbers);
            Console.ReadKey();

            return sortedNumbers;
        }

        // Print the elements from generic-type array
        private static void DisplayResult(T[] numbers)
        {
            foreach (T number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
