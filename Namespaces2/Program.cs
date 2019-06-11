using System;

/* This DLL contains outer namespace MyNameSpace and sub namespace ChildSpace.
 * Both namespaces contain a class called Policies.
 * Namespace aliasing is used to access these classes.
 */

namespace MyNameSpace
{
    namespace ChildSpace
    {
        internal class Policies
        {
            private const string msg = 
                "I am from MyNameSpace.ChildSpace.Policies";

            public static void printMessage()
            {
                Console.WriteLine(msg);
            }
        }
    }

    internal class Policies
    {
        private const string msg = "I am from MyNameSpace.Policies";

        public static void printMessage()
        {
            Console.WriteLine(msg);
        }
    }
}

namespace Namespaces2
{
    /* Namespace Aliasing */
    using ParentPolicy = MyNameSpace.Policies;
    using ChildPolicy = MyNameSpace.ChildSpace.Policies;

    class Program
    {
        static void Main(string[] args)
        {
            ParentPolicy.printMessage();
            ChildPolicy.printMessage();
        }
    }
}
