using System;

/* Accepts the size of a square's side and prints area of the square.
 * Ensures the user input is a non-negative number.
 */

namespace VariablesAndExpressions2
{
    class Program
    {
        static void Main()
        {
            float len = -1;
            while (len < 0)
            {
                Console.Write("Side length of square: ");
                string input = Console.ReadLine();
                try
                {
                    len = Convert.ToSingle(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number greater than or equal to zero.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input. Overflow limit is exceeded.");
                }
            }
            Console.WriteLine("Area of square: {0}", len*len);
        }
    }
}
