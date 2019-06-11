using System;

/* Create an Apple and Orange and Eat() them to show overridden 
 * Fruit behavior 
 */

namespace ClassesAndStructs6
{
    class Program
    {
        static void Main(string[] args)
        {
            Fruit apple = new Apple("apple", "sweet and crunchy", "medium");
            Fruit orange = new Orange("orange", "sweet and sour", "medium");

            apple.eat();
            orange.eat();
        }
    }
}
