namespace SortingAlgorithms.Utilities
{
    internal static class UserInterfaceMessages
    {
        // User inputs
        internal const string QuestionInputFileName = "Type the number of elements which you want to sort" +
                                                      "\n(e.g. \"1_000\", \"10_000\", or \"100_000\"):";
        internal const string QuestionInputSortingMethod = "\nType a name of sorting method algorithm" +
                                                           "\n(e.g. \"Bubble\", or \"Quick\"):";
        internal const string QuestionInputSortingOrder = "\nType an order of sorting" +
                                                          "\n(e.g. \"ASC\", or \"DESC\"):";
        internal const string QuestionInputSaveFile = "\nSave a file with the sorted numbers?" +
                                                      "\n(Y)es to ACCEPT, or other to EXIT:\n";
        internal const string WaitingForPressKey = "\nPress any key to display the sorted numbers:";

        // Information messages
        internal const string WaitingMessage = "\nWaiting...";
        internal const string PerformanceHeader = "\nPerformance mesurement:";

        // Error messages
        internal const string ErrorSortingOrder = "\nThere is no such sorting order!\n";
        internal const string ErrorSortingMethod = "\nThere is no such algorithm!\n";
        internal const string ErrorDisplayingTime = "\nFailed to get timestamp. Error code: ";
    }
}
