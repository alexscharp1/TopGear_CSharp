using System;

namespace ClassLibrary1
{
    internal class FirstT
    {
        private static string msg1;
        private string msg2;

        static FirstT()
        {
            msg1 = "I'm a private static field from FirstT";
        }

        public FirstT()
        {
            msg2 = "I'm a private instance field from FirstT";
        }

        public static void printStaticMessage()
        {
            Console.WriteLine(msg1);
        }

        public void printInstanceMessage()
        {
            Console.WriteLine(msg2);
        }
    }
}
