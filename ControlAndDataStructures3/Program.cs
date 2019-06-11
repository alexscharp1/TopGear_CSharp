using System;

/* Checks whether input string is a palindrome.
 * Ignores letter case and surrounding whitespace.
 */

namespace ControlAndDataStructures3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Input a string: ");
            string str = Console.ReadLine().Trim().ToLower();

            int len = str.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (str[i] != str[len-i-1])
                {
                    // Mismatch found
                    Console.WriteLine("Not a palindrome.");
                    return;
                }
            }
            // All pairs match
            Console.WriteLine("Palindrome!");
        }
    }
}
