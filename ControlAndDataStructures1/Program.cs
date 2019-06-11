using System;

/* Accepts a number and prints whether the number is even or odd. */
namespace ControlAndDataStructures1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            // Get user input
            while (true)
            {
                Console.Write("Input an integer: ");
                string input = Console.ReadLine();
                try
                {
                    num = Convert.ToInt32(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input. Overflow limit is exceeded.");
                }
            }
            // Output result
            Console.WriteLine("{0} is an {1} number.", num,
                (num % 2 == 0) ? "even" : "odd" );
        }
    }
}
