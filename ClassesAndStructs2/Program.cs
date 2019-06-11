using System;

/* Calls static methods of RandomHelper class to generate and display
 * random integers and doubles.
 */

namespace ClassesAndStructs2
{
    class Program
    {
        private static int GetInputInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    return Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Invalid input. Please enter an integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "Invalid input. Overflow limit is exceeded.");
                }
            }
        }

        private static int GetInputLowerBound(string prompt)
        {
            return GetInputInt(prompt);
        }

        private static int GetInputUpperBound(string prompt, int lower)
        {
            int upper = lower - 1;
            while (upper < lower)
            {
                upper = GetInputInt(prompt);
                if (upper < lower)
                {
                    Console.WriteLine(
                        "Invalid Input: Upper bound cannot be less than " +
                        "lower bound.");
                }
            }
            return upper;
        }

        static void Main(string[] args)
        {
            int a = GetInputLowerBound("Input integer lower bound: ");
            int b = GetInputUpperBound("Input integer upper bound: ", a);
            int numCount = GetInputInt(
                "Input count of random numbers to generate: ");


            // Generate random ints
            Console.WriteLine(
                "\nGenerating {0} random integers between {1} and {2}...",
                numCount, a, b);
            for (int i = 0; i < numCount; i++)
            {
                Console.WriteLine("{0}:\t{1}", i + 1, 
                    RandomHelper.randint(a, b));
            }

            // Generate random doubles
            Console.WriteLine(
                "\nGenerating {0} random doubles between {1} and {2}...",
                numCount, a, b);
            for (int i = 0; i < numCount; i++)
            {
                Console.WriteLine("{0}:\t{1}", i + 1, 
                    RandomHelper.randdouble(a, b));
            }
        }
    }
}
