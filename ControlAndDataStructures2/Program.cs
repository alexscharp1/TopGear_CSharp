using System;

/* Generates first 20 fibonacci numbers */

namespace ControlAndDataStructures2
{
    class Program
    {
        // First 2 fibonacci numbers
        private static int f0 = 0;
        private static int f1 = 1;

        // Get next fibonacci number by adding previous 2

        static void Main()
        {
            int prev, curr, next;
            int count = 20;

            Console.WriteLine("First {0} Fibonacci numbers:", count);

            // Print first two fib numbers
            prev = f0;
            Console.WriteLine(prev);
            curr = f1;
            Console.WriteLine(curr);

            // Iteratively print remainaing Fib numbers
            for (int i = 2; i < count; i++)
            {
                next = prev + curr;
                Console.WriteLine(next);
                // Increment prev and curr
                prev = curr;
                curr = next;
            }

        }
    }
}
