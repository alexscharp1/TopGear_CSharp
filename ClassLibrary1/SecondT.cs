using System;
using ClassLibrary1;

namespace ClassLibrary1
{
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
