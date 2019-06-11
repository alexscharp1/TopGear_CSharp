using System;

/* Accepts five numbers, stores them in an array, and prints the numbers. */

namespace Arrays1
{
    class Program
    {
        // Count of numbers
        private const int COUNT = 5;

        // Prompts user for an int until valid input is provided.
        private static int getUserNumber(int i)
        {
            while (true)
            {
                Console.Write("Input integer {0}: ", i+1);
                string input = Console.ReadLine();
                try
                {
                    return Convert.ToInt32(input);
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
        }

        static void Main(string[] args)
        {
            // Populate array with user input
            int[] nums = new int[COUNT];
            for (int i = 0; i < COUNT; i++)
            {
                nums[i] = getUserNumber(i);
            }

            // Print array
            Console.WriteLine("The numbers provided are as follows:");
            for (int i = 0; i < COUNT; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
