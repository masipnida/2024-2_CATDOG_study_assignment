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
            double math_ave;
            double sci_ave;
            double eng_ave;

            for(int i = 1; i <= stdCount; i++)
            {
                math_ave += data[i, 2];
                sci_ave += data[i, 3];
                eng_ave += data[i, 4];
            }
            math_ave = math_ave / stdCount;
            sci_ave = sci_ave / stdCount;
            eng_ave = eng_ave / stdCount;
            Console.WriteLine($"Average Scores:\nMath: {math_ave}\nScience: {sci_ave}\nEnglish: {eng_ave}");

            double[] math_mm = MaxMin(data, 2);
            double[] sci_mm = MaxMin(data, 3);
            double[] eng_mm = MaxMin(data, 4);
            Console.WriteLine("Max and min Scores\nMath: ({0}, {1})\nScience: ({2}, {3})\nEnglish: ({4}, {5})", math_mm[0], math_mm[1], sci_mm[0], sci_mm[1], eng_mm[0], eng_mm[1]);

            string[] rank_s = Rank(data, stdCount);
            Console.WriteLine("Students rank by total scores:\n");
            for (int i = 0; i < stdCount; i++)
            {
                Console.WriteLine($"{rank_s[i + 1]}: {i}");
                switch (i)
                {
                    case 1:
                        Console.WriteLine("st\n");
                        break;
                    case 2:
                        Console.WriteLine("nd\n");
                        break;
                    case 3:
                        Console.WriteLine("rd\n");
                        break;
                    default:
                        Console.WriteLine("th\n");
                }
            }
            // --------------------
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
