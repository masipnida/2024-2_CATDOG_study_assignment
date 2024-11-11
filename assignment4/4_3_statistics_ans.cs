using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            
            // --------------------
        }

        public int Average(string[,] data, int count, int pick)
        {
            int sum = 0;
            for (int i = 1; i <= count; i++)
            {
                sum += double.Parse(data[i, pick]);
            }
            return sum / count;
        }

        public int[] MaxMin(string[,] data, int count)
        {
            int arr = new int[2];
            arr[0] = double.Parse(data[1, 2]);
            arr[1] = double.Parse(data[1, 2]);
            for (int i = 1; i <= count; i++)
            {
                for (int j = 2; j <= 4; j++)
                {
                    if (double.Parse(data[i, j]) > arr[0])
                    {
                        arr[0] = double.Parse(data[i, j]);
                    }
                    
                    if (double.Parse(data[i, j]) < arr[1])
                    {
                        arr[1] = double.Parse(data[i, j]);
                    }
                }
            }
            return arr;
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 4th
Bob: 1st
Charlie: 5th
David: 2nd
Eve: 3rd

*/
