using System;

namespace ClassesAndStructs6
{
    class Fruit
    {
        private string name;
        private string taste;
        private string size;

        public Fruit(string name, string taste, string size)
        {
            this.name = name;
            this.taste = taste;
            this.size = size;
        }

        public virtual void eat()
        {
            // a or an (depending if fruit starts with vowel)
            string a = ("aeiouAEIOU".IndexOf(name[0]) >= 0) ? "an" : "a";
            Console.WriteLine("This is {0} {1}. It tastes {2}.", a, name, taste);
        }
    }
}
