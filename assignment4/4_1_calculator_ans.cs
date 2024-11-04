using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        // ---------- TODO ----------
        public double Calculate(double num1, string op, double num2)
        {
            double ans;
            switch (op)
            {
                case "+": 
                    ans = num1 + num2;
                    break;
                case "-":
                    ans = num1 - num2;
                    break;
                case "*":
                    ans = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Division by zero is not allowed");
                    }
                    else
                    {
                        ans = num1 / num2;
                        break;
                    }
                case "%":
                    int a = (int) num1;
                    int b = (int) num2;
                    ans = a % b;
                    break;
                case "**":
                    int k = (int) num2;
                    ans = Math.Pow(num1, k);
                    break;
                case "G":
                    ans = Calculate_Max(num1, num2);
                    break;
                case "L":
                    int p = (int) num1;
                    int q = (int) num2;
                    ans = ( p * q )/ Calculate_Max(num1, num2);
                    break;
                default:
                    throw new InvalidOperationException("Invalid operator");
            }

            return ans;
        }

        public int Calculate_Max(double num1, double num2)
        {
            int c;
            int a = (int) num1;
            int b = (int) num2;

            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            return a;
        }
        // --------------------
    }
}

/* example output

Enter an expression (ex. 2 + 3):
>> 4 * 3
Result: 12

*/


/* example output (CHALLANGE)

Enter an expression (ex. 2 + 3):
>> 4 ** 3
Result: 64

Enter an expression (ex. 2 + 3):
>> 5 ** -2
Result: 0.04

Enter an expression (ex. 2 + 3):
>> 12 G 15
Result: 3

Enter an expression (ex. 2 + 3):
>> 12 L 15
Result: 60

Enter an expression (ex. 2 + 3):
>> 12 % 5
Result: 2

*/