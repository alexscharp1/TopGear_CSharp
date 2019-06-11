using System;

namespace Generics1
{
    class Program
    {
        private static T[] Insert<T>(T[] array, T value, int pos)
        {
            int len = array.Length;
            if (pos < 0 || pos >= len)
            {
                throw new IndexOutOfRangeException();
            }

            // Create new array, fill with array values and new value
            T[] result = new T[len + 1];
            int i = 0;
            for (; i < pos; i++)
            {
                result[i] = array[i];
            }
            result[i] = value;
            for (; i < len; i++)
            {
                result[i + 1] = array[i];
            }

            return result;
        }

        private static T[] Delete<T>(T[] array, int pos)
        {
            int len = array.Length;
            if (pos < 0 || pos >= len)
            {
                throw new IndexOutOfRangeException();
            }

            // Create new array, fill with array values excluding deleted one
            T[] result = new T[len - 1];
            int i = 0;
            for (; i < pos; i++)
            {
                result[i] = array[i];
            }
            for (i++; i < len; i++)
            {
                result[i - 1] = array[i];
            }

            return result;
        }

        private static void Print<T>(T[] array)
        {
            int len = array.Length;
            for (int i = 0; i < len; i++)
            {
                Console.Write("{0}\t", array[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Int array
            int[] intArray = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Int array original contents:");
            Print(intArray);
            intArray = Insert(intArray, 50, 3);
            Console.WriteLine("Int array after insertion:");
            Print(intArray);
            intArray = Delete(intArray, 1);
            Console.WriteLine("Int array after deletion:");
            Print(intArray);

            // Char array
            char[] charArray = new char[] { 'a', 'b', 'c' };
            Console.WriteLine("\nChar array original contents:");
            Print(charArray);
            charArray = Insert(charArray, 'z', 2);
            Console.WriteLine("Char array after insertion:");
            Print(charArray);
            charArray = Delete(charArray, 1);
            Console.WriteLine("Char array after deletion:");
            Print(charArray);

            // String array
            Console.WriteLine("String array...");
            string[] strArray = new string[] { "Hello", "Bonjour", "Hola" };
            Console.WriteLine("\nString array original contents:");
            Print(strArray);
            strArray = Insert(strArray, "Ni hao", 1);
            Console.WriteLine("String array after insertion:");
            Print(strArray);
            strArray = Delete(strArray, 2);
            Console.WriteLine("String array after deletion:");
            Print(strArray);
        }
    }
}
