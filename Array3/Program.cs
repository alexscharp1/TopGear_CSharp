using System;

/* Static Method creates and returns 3x5 array of 42's */

namespace Arrays3
{
    class Program
    {
        static int[,] Method()
        {
            return new int[3, 5]
                {
                    { 42, 42, 42, 42, 42 },
                    { 42, 42, 42, 42, 42 },
                    { 42, 42, 42, 42, 42 }
                };
        }

        private static void printMatrix(int[,] A)
        {
            int rowLength = A.GetLength(0);
            int colLength = A.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write("{0}\t", A[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] A = Method();
            printMatrix(A);
        }
    }
}
