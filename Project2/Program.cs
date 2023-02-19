using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Project2
{
    public class Program
    {
        public static void Main()
        {
            int[][] numbers = new int[20][];
                        
            StreamReader reader = new StreamReader(@"..\..\..\inputJagged.csv");

            // Reads lines while there are still lines to be read
            while (!reader.EndOfStream)
            {
                // Loops through each of the 20 jagged arrays in numbers
                for(int i = 0; i < numbers.Length; i++)
                {
                    var eachLine = reader.ReadLine();
                    var numValues = eachLine.Split(',');
                    numbers[i] = new int[numValues.Length];

                    // Loops through each of the j values in the numbers[i] array
                    for(int j = 0; j < numValues.Length; j++)
                    {
                        numbers[i][j] = Convert.ToInt32(numValues[j]);
                    }
                }
            }
        }

        #region QuickSort()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        /// <returns></returns>
        public int[] QuickSort(int[] numbers, int leftIndex, int rightIndex)
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
        public int BinarySearch(int[] numbers, int targetValue)
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
                    return targetValue;
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