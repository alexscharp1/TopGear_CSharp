using System;

/* Creates a delegate type that points to several methods which take an array 
 * of ints and performs operations on the array.
 * The methods are Print(), Reverse(), and Sort().
 */

namespace Collections1
{
    class Program
    {
        delegate void MyDelegate(int[] arr);

        private static void Print(int[] arr)
        {
            Console.WriteLine("Printing array:");
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                Console.Write("{0}\t", arr[i]);
            }
            Console.WriteLine();
        }

        private static void Reverse(int[] arr)
        {
            Array.Reverse(arr);
            Console.WriteLine("Array reversed.");
        }
        private static void Sort(int[] arr)
        {
            Array.Sort(arr);
            Console.WriteLine("Array sorted.");
        }
        static void Main(string[] args)
        {
            // Create array
            int[] arr = new int[]
            {
                8, 2, 3, 0, 1, 9, 5
            };

            // Setup delegate
            MyDelegate myDelegate = null;
            myDelegate += Print;
            myDelegate += Reverse;
            myDelegate += Print;
            myDelegate += Sort;
            myDelegate += Print;

            myDelegate.Invoke(arr);
        }
    }
}
