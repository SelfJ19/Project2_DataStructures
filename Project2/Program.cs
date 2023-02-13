using System.Security.Cryptography.X509Certificates;

namespace Project2
{
    public class Program
    {
        public static void Main()
        {
            int[][] numbers = new int[20][];
                        
            StreamReader reader = new StreamReader(@"..\..\..\inputJagged.csv");
            string line = reader.ReadLine();
            while((line = reader.ReadLine()) != null)
            {
                string[] num = line.Split(",");
                Convert.ToInt32(num);
                for (int i = 0; i < num.Length; i++)
                {
                    
                }
            }
            Console.WriteLine(line);
        }

        #region QuickSort()
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

        public void BinarySearch()
        {

        }
    }
}