using System;

/* Accept an input number which will be used in division.
 * This division will eventually cause an exception by dividing by zero. 
 * Handel this with a try-catch-finally block.
 */

namespace ExceptionHandling1
{
    class Program
    {
        private static decimal GetUserNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    return Convert.ToDecimal(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "Invalid input. Overflow limit is exceeded.");
                }
            }
        }

        static void Main(string[] args)
        {
            // Accept numbers from user
            decimal a = GetUserNumber("Numerator: ");
            decimal b = GetUserNumber("Denominator: ");

            // Divide
            try
            {
                decimal c = a / b;
                Console.WriteLine("Result of division: {0}", c);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Invalid result: Cannot divide by zero.");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
