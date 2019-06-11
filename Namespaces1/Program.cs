using System;

/* MyLibrary DLL contains two classes FirstT and SecondT.
 * FirstT is hidden in the namespaces, and SecondT is exposed.
 * Class SecondT exposes the features of class FirstT indirectly.
 */
namespace MyLibrary
{
    // Hidden class which contains static and non-static fields and methods
    internal class FirstT
    {
        private readonly static string msg1;
        private readonly string msg2;

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

    // Exposes contents of FirstT
    public class SecondT
    {
        private FirstT myFirstT;

        public SecondT()
        {
            myFirstT = new FirstT();
        }

        public void exposeStaticField()
        {
            FirstT.printStaticMessage();
        }

        public void exposeInstanceField()
        {
            myFirstT.printInstanceMessage();
        }
    }
}


namespace Namespaces1
{
    using MyLibrary;

    class Program
    {
        static void Main(string[] args)
        {
            SecondT mySecondT = new SecondT();
            mySecondT.exposeStaticField();
            mySecondT.exposeInstanceField();
        }
    }
}
