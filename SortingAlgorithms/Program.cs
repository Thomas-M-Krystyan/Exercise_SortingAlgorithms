using System;
using System.IO;
using SortingAlgorithms.Controllers;
using static SortingAlgorithms.Utilities.UserInterfaceMessages;

namespace SortingAlgorithms
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            // -------------------------------------------------------------
            // ARRANGE (Prepares data and choices for further manipulations)
            // -------------------------------------------------------------
            #region User input (file name)
                Console.WriteLine(QuestionInputFileName);
                string inputNumber = Console.ReadLine();
            #endregion

            #region Prepared file path
                const string catalogName = @"NumberSets\";
                string fileName = $"random_numbers_{inputNumber}.txt";

                // Relative paths
                string filePathIn = Path.Combine(Environment.CurrentDirectory, catalogName, fileName);  
                string filePathOut = Path.Combine(Environment.CurrentDirectory, catalogName);
            #endregion

            #region User input (sorting method)
                Console.WriteLine(QuestionInputSortingMethod);
                string algorithmName = Console.ReadLine();
            #endregion

            #region User input (sorting order)
                Console.WriteLine(QuestionInputSortingOrder);
                string sortingOrder = Console.ReadLine();
            #endregion

            // ----------------------------------------------------------
            // ACT (Invokes sorting algorithms and calculating CPU usage)
            // ----------------------------------------------------------
            var result = ProgramController<int>.Start(filePathIn, algorithmName, sortingOrder);
            ProgramController<int>.Finish(filePathOut, fileName, result);
        }
    }
}
