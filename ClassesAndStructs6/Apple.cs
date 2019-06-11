using System;

namespace ClassesAndStructs6
{
    class Apple : Fruit
    {
        public Apple(string name, string taste, string size)
            : base(name, taste, size) { }

        public override void eat()
        {
            Console.WriteLine("This is an apple!!! Yummmmm, " +
                "it tastes so sweet and crunchy.");
        }
    }
}
