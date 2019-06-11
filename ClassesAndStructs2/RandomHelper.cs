using System;

/* Generates random numbers given range inputs */

namespace ClassesAndStructs2
{
    class RandomHelper
    {

        // Returns a random int, a <= result <= b
        public static int randint(int a, int b)
        {
            Random rand = new Random();
            return rand.Next(a, b + 1);
        }

        // Returns a random double, a < result < b
        public static double randdouble(int a, int b)
        {
            Random rand = new Random();
            return rand.NextDouble() * (b - a) + a;
        }
    }
}
