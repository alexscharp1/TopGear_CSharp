using System;

namespace ClassesAndStructs6
{
    class Orange : Fruit
    {
        public Orange(string name, string taste, string size)
            :base (name, taste, size) { }

        public override void eat()
        {
            Console.WriteLine("Wow, and orange! It tastes sweet and sour.");
        }
    }
}
