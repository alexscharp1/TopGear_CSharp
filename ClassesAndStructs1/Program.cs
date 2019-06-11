using System;

/* Creates an Employee object and displays its information. */

namespace ClassesAndStructs1
{
    class Program
    {
        private static string GetInputName()
        {
            while (true)
            {
                Console.Write("Input employee name: ");
                string input = Console.ReadLine();
                if (input.Length > 20)
                {
                    Console.WriteLine("Invalid name. Limit to 20 characters.");
                }
                else
                {
                    return input;
                }
            }
        }

        private static int GetInputSalary()
        {
            while (true)
            {
                Console.Write("Input employee salary (USD): ");
                string input = Console.ReadLine();
                try
                {
                    int num = Convert.ToInt32(input);
                    if (num <= 0)
                    {
                        Console.WriteLine("Invalid input. Salary must be positive.");
                    }
                    else
                    {
                        // Valid input
                        return num;
                    }

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
            }
        }

        static void Main(string[] args)
        {
            string name = GetInputName();
            decimal salary = GetInputSalary();
            Employee emp = new Employee(name, salary);
            emp.Display();
        }
    }
}
