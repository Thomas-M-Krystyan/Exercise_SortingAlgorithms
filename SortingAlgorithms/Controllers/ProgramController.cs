using System;
using static SortingAlgorithms.Utilities.UserInterfaceMessages;

namespace SortingAlgorithms.Controllers
{
    internal static class ProgramController<T> where T : IComparable, IConvertible
    {
        // Reads data, converts it to generic-type and sorts by algorithm chosen by the user
        internal static T[] Start(string filePathIn, string algorithmName, string sortingOrder)
        {
            T[] preparedData = FileController<T>.GetData(filePathIn);
            return SortingController<T>.ChooseMethod(preparedData, algorithmName, sortingOrder);
        }

        // Writes current data with sorted numbers in the original directory (prefix: "sorted_")
        internal static void Finish(string filePathOut, string fileName, T[] result)
        {
            Console.WriteLine(QuestionInputSaveFile);
            string decision = Console.ReadLine();

            if (decision != null && (decision.ToLower().Equals("y") || decision.ToLower().Equals("yes")))
            {
                FileController<T>.SaveData(filePathOut, fileName, result);
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
