using System;
using System.Text.RegularExpressions;

/* Accepts a string and performs several string manipulations:
 * 1) Print the reverse string,
 * 2) Extract part of the string from position 1 to end,
 * 3) Replace any character by '$',
 * 4) Copy string to another string variable and print them both.
 */

namespace ControlAndDataStructures4
{
    class Program
    {
        private static string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private static string ExtractSubString(string str)
        {
            return str.Substring(1);
        }

        private static string ReplaceChars(string str)
        {
            return Regex.Replace(str, "[a-zA-Z]", "$");
        }

        private static string CopyString(string str)
        {
            return String.Copy(str);
        }

        static void Main(string[] args)
        {
            // Get user's string
            string str = String.Empty;
            while (str == String.Empty)
            {
                Console.Write("Provide a string to manipulate: ");
                str = Console.ReadLine();
                if (str == String.Empty)
                {
                    Console.WriteLine("String cannot be empty.");
                }
            }

            // Perform string manipulations
            Console.WriteLine("Reverse string: {0}", ReverseString(str));
            Console.WriteLine("Substring from second position to end: {0}",
                ExtractSubString(str));
            Console.WriteLine("Replace characters with '$': {0}",
                ReplaceChars(str));
            Console.WriteLine("Original string: {0}", str);
            Console.WriteLine("Copied string: {0}", CopyString(str));
        }
    }
}
