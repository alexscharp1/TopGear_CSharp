using System;

/* Demonstrate the funcionality of Fan objects */

namespace ClassesAndStructs3
{
    class Program
    {
        private static void SetSpeed(Fan fan)
        {
            while (true)
            {
                Console.Write("Speed: ");
                string input = Console.ReadLine();
                try
                {
                    int speed = Convert.ToInt32(input);
                    fan.SetSpeed(speed);
                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Invalid input. Please enter an integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "Invalid input. Overflow limit is exceeded.");
                }
                catch (InvalidSpeedException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void SetOn(Fan fan)
        {
            while (true)
            {
                Console.Write("On: ");
                string input = Console.ReadLine();
                try
                {
                    bool on = Convert.ToBoolean(input);
                    fan.SetOn(on);
                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Invalid input. Please enter a boolean (true/false).");
                }
            }
        }

        private static void SetRadius(Fan fan)
        {
            while (true)
            {
                Console.Write("Radius: ");
                string input = Console.ReadLine();
                try
                {
                    double radius = Convert.ToDouble(input);
                    fan.SetRadius(radius);
                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Invalid input. Please enter a number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "Invalid input. Overflow limit is exceeded.");
                }
                catch (InvalidRadiusException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void SetColor(Fan fan)
        {
            while (true)
            {
                Console.Write("Color: ");
                string color = Console.ReadLine();
                try
                {
                    fan.SetColor(color);
                    return;
                }
                catch (InvalidColorException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            // Test constructor
            Fan fan = new Fan();

            // Test getters
            Console.WriteLine("Getting default values...");
            Console.WriteLine("Speed: {0}", fan.GetSpeed());
            Console.WriteLine("On: {0}", fan.GetOn());
            Console.WriteLine("Radius: {0:0.00}", fan.GetRadius());
            Console.WriteLine("Color: {0}", fan.GetColor());

            // Test setters
            Console.WriteLine("\nSet the values...");
            SetSpeed(fan);
            SetOn(fan);
            SetRadius(fan);
            SetColor(fan);

            // Test ToString
            Console.WriteLine("\nPrinting fan details...");
            Console.WriteLine(fan.ToString());
        }
    }
}
