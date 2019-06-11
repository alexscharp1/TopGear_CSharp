using System;

/* Modifies ControlAndDataStructure5 - Convert int to Calendar Date.
 * When accepting user's input, throw InvalidArgument exception if the value
 * is out of range (1 to 365).
 */

namespace ExceptionHandling3
{
    class Program
    {
        private static string[] months;
        private static int[] daysPerMonth;

        // Provide structure for grouping month and day of month
        internal struct Date
        {
            public string month;
            public int day;

            public void Print()
            {
                Console.WriteLine("{0} {1}", month, day);
            }
        }

        static Program()
        {
            // Init static variables
            months = new string[]
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November",
                "December"
            };
            daysPerMonth = new int[]
            {
                31, // January
                28, // February
                31, // March
                30, // April
                31, // May
                30, // June
                31, // July
                31, // August
                30, // September
                31, // October
                30, // November
                31  // December
            };
        }

        private static int getInputNumber()
        {
            while (true)
            {
                Console.Write("Input an integer between 1 and 365: ");
                string input = Console.ReadLine();
                try
                {
                    int num = Convert.ToInt32(input);
                    if (num < 1 || num > 365)
                    {
                        throw new InvalidArgumentException();
                    }
                    // Valid input
                    return num;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input. Overflow limit is exceeded.");
                }
                catch (InvalidArgumentException)
                {
                    Console.WriteLine("Invalid input. Number must be between 1 and 365, inclusive.");
                }
            }
        }

        private static Date GetDate(int num)
        {
            // Compute month and day
            int m = 0; // Month index
            while (num > daysPerMonth[m])
            {
                num -= daysPerMonth[m];
                m++;
            }

            // Return results
            return new Date() { month = months[m], day = num };
        }

        static void Main(string[] args)
        {
            // Get int from user
            int num = getInputNumber();

            // Get month and day
            Date date = GetDate(num);
            date.Print();
        }
    }
}
