using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Project2
{
    public class Program
    {
        #region Main()
        /// <summary>
        /// Creates the main method that calls and uses the other methods
        /// </summary>
        public static void Main()
        {
            int[][] numbers = new int[20][];
            
            // File path relative to location of the program.
            string filePath = @"../../../inputJagged.csv";

            numbers = ReadCSV(filePath);

            // loops the numbers array and passes it into the quicksort method
            for (int i = 0; i < numbers.Length; i++)
            {
                QuickSort(numbers[i], 0, numbers[i].Length -1);
            }
            PrintArray(numbers);

            Console.WriteLine("If the index says -1 that means the value was not found otherwise it is found at that index.\n");

            // loops the array after being sorted into the BinarySearch method to look for a specific value
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Value at Index {BinarySearch(numbers[i], 256)} in array {i}");
            }
        }
        #endregion

        #region ReadCSV()
        /// <summary>
        /// Creates the method that will read in the file
        /// </summary>
        /// <param name="fileName">path to the file that is being read in</param>
        /// <returns>the array after the file is read</returns>
        public static int[][] ReadCSV(string fileName)
        {
            int[][] numbers = new int[20][];
            StreamReader reader = new StreamReader(fileName);

            int index = 0;
            while (!reader.EndOfStream)
            {
                string eachLine = reader.ReadLine();
                int[] numValues = eachLine.Split(',').Select(x => x.Trim()).Select(x => int.Parse(x)).ToArray();

                // Add the integers we just read to the array.
                numbers[index] = numValues;
                index++;
            }
            return numbers;
        }
        #endregion

        #region PrintArray()
        /// <summary>
        /// Creates the print method for the format of how the array is shown in the console
        /// </summary>
        /// <param name="numbers">array that is passed in to be formated for print out</param>
        public static void PrintArray(int[][] numbers)
        {
            // Prints out array
            foreach (int[] numArray in numbers)
            {
                foreach (int num in numArray)
                {
                    Console.Write($"{num} | ");
                }
                Console.WriteLine("\n");
            }
        }
        #endregion

        #region QuickSort()
        /// <summary>
        /// Method that sorts through an array using pointers and pivots and recursively calls itself to sort the array
        /// </summary>
        /// <param name="numbers">name of the array being passed in</param>
        /// <param name="leftIndex">index at the beginning of the array</param>
        /// <param name="rightIndex">index at the end of the array</param>
        /// <returns>the array after being sorted</returns>
        public static int[] QuickSort(int[] numbers, int leftIndex, int rightIndex)
        {
            int a = leftIndex;
            int b = rightIndex;
            int pivot = numbers[leftIndex];
            while (a <= b)
            {
                while (numbers[a] < pivot)
                {
                    a++;
                }

                while (numbers[b] > pivot)
                {
                    b--;
                }

                if (a <= b)
                {
                    int temp = numbers[a];
                    numbers[a] = numbers[b];
                    numbers[b] = temp;
                    a++;
                    b--;
                }
            }
            if (leftIndex < b)
            {
                QuickSort(numbers, leftIndex, b);
            }
            if (a < rightIndex)
            {
                QuickSort(numbers, a, rightIndex);
            }
            return numbers;
        }
        #endregion

        #region BinarySearch()
        /// <summary>
        /// Method that searches through the array until it either finds or doesn't find the value
        /// </summary>
        /// <param name="numbers">name of the array</param>
        /// <param name="targetValue">the value being searched for</param>
        /// <returns>either the value that was being searched for or -1 if not found</returns>
        public static int BinarySearch(int[] numbers, int targetValue)
        {
            bool checker = false;
            int counter = 0;
            int firstIndex = 0;
            while (counter < numbers.Length -1)
            {
                int middleIndex = ((firstIndex + (numbers.Length - 1)) / 2);

                if(numbers[middleIndex] == targetValue)
                {
                    checker = true;
                    return middleIndex;
                }
                else if (numbers[middleIndex] > targetValue)
                {
                    firstIndex--;
                    counter++;
                }
                else if(numbers[middleIndex] < targetValue)
                {
                    firstIndex++;
                    counter++;
                }
            }
            return -1;
        }
        #endregion
    }
}