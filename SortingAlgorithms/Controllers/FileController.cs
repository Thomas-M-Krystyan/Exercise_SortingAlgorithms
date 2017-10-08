using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SortingAlgorithms.Controllers
{
    internal static class FileController<T> where T : IConvertible
    {
        // Prepare the data to manipulation
        internal static T[] GetData(string filePathIn)
        {
            return GenericConversion(FileReader(filePathIn));
        }

        // Read the file with randomly generated numbers
        private static string[] FileReader(string filePathIn)
        {
            string[] stringsArray = new string[] {};

            try
            {
                // Read the whole file line-by-line --> return: string
                string fileContent = File.ReadAllText(filePathIn);

                // Split the received data by separators --> return: string[]
                char[] separators = new char[] {',', ' ', '\t', '\r', '\n'};
                stringsArray = fileContent.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (FileNotFoundException ioException)
            {
                Console.WriteLine("\n" + ioException.Message + "\n");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return stringsArray;
        }

        // Convert file content to generic-type array
        private static T[] GenericConversion(string[] stringsArray)
        {
            // Convert achieved strings to integers --> return: T[]
            T[] integersArray = new T[stringsArray.Length];
            for (int i = 0; i < stringsArray.Length; i++)
            {
                integersArray[i] = (T) Convert.ChangeType(stringsArray[i], typeof(T));
            }

            return integersArray;
        }

        // Prepare the data to saving
        internal static void SaveData(string filePathOut, string fileName, T[] result)
        {
            StringBuilder newFilePathOut = new StringBuilder();

            // Prepare new file path
            newFilePathOut.Append(filePathOut);
            newFilePathOut.Append("sorted_");
            newFilePathOut.Append(fileName);

            // Prepare data content
            string[] convertedResult = GenericReconversion(result);

            FileWriter(newFilePathOut.ToString(), convertedResult);
        }

        // Convert sorted numbers to string array
        private static string[] GenericReconversion(T[] result)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (i == result.Length - 1)
                {
                    stringBuilder.Append(result[i]);
                    break;
                }
                stringBuilder.Append(result[i] + ", ");
            }
            string[] convertedResult = new string[] { stringBuilder.ToString() };

            return convertedResult;
        }

        // Save new data to the following file path
        private static void FileWriter(string newFilePathOut, string[] convertedResult, int counter = 1)
        {
            if (convertedResult != null)
            {
                if (File.Exists(path: newFilePathOut))
                {
                    StringBuilder changedNewFilePathOut = new StringBuilder();

                    // Prepare changed new file path
                    Regex regex = new Regex(@"(\(\d+\)\.txt)|(\.txt)");
                    string result = regex.Replace(input: newFilePathOut, replacement: $"({counter}).txt");

                    changedNewFilePathOut.Append(result);
                    
                    FileWriter(newFilePathOut: changedNewFilePathOut.ToString(),
                               convertedResult: convertedResult, counter: counter + 1);
                }
                else
                {
                    File.WriteAllLines(path: newFilePathOut, contents: convertedResult, encoding: Encoding.UTF8);
                }
            }
        }
    }
}
