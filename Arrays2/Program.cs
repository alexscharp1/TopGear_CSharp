using System;

/* Accepts 4 ints from user and stores them in a 2x2 matrix.
 * Accepts 4 more ints and stores them in another 2x2 matrix.
 * Multiplies the two matrices together, stores result in a 2x2 matrix,
 * and prints the resulting matrix.
 */

namespace Arrays2
{
    class Program
    {
        private static int getUserInt(int i)
        {
            while (true)
            {
                Console.Write("Integer for cell [{0}, {1}]: ", i / 2, i % 2);
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

        private static int[,] createMatrix()
        {
            int[,] A = new int[2, 2];
            for (int i = 0; i < 4; i++)
            {
                A[i / 2, i % 2] = getUserInt(i);
            }
            return A;
        }

        private static void printMatrix(int[,] A)
        {
            int rowLength = A.GetLength(0);
            int colLength = A.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write("{0}\t", A[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static int[,] multiplyMatrices(int[,] A, int[,] B)
        {
            int[,] C = new int[2, 2];
            C[0, 0] = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0];
            C[0, 1] = A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1];
            C[1, 0] = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0];
            C[1, 1] = A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1];
            return C;
        }

        static void Main(string[] args)
        {
            // Computes C = A * B, where A, B, C are all 2x2 matrices
            int[,] A, B, C;

            Console.WriteLine("Create first 2x2 matrix:");
            A = createMatrix();
            printMatrix(A);
            Console.WriteLine("Create second 2x2 matrix:");
            B = createMatrix();
            printMatrix(B);

            C = multiplyMatrices(A, B);
            Console.WriteLine("Product of first and second matrices:");
            printMatrix(C);
        }
    }
}
