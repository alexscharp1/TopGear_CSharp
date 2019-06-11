using System;

namespace MyNameSpace
{
    namespace ChildSpace
    {
        public class Policies
        {
            private const string msg = "I am from MyNameSpace.ChildSpace.Policies";

            public static void printMessage()
            {
                Console.WriteLine(msg);
            }
        }
    }

    public class Policies
    {
        private const string msg = "I am from MyNameSpace.Policies";

        public static void printMessage()
        {
            Console.WriteLine(msg);
        }
    }
}
