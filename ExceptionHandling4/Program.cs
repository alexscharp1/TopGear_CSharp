using System;

/* Modifies ExceptionHandling3 - Convert int to Calendar Date.
 * Prompt the user for a year, and detect whether it is a leap year.
 * If it is, accept day numbers 1 to 366.
 * Additionally, uses a foreach statement to correctly calculate 
 * the month and day pair for leap years.
 */

namespace ExceptionHandling4
{
    class Program
    {
        private static string[] months;
        private static int[] daysPerMonth;

        // Provide structure for grouping month and day of month
        internal struct Date
        {
            public int year;
            public string month;
            public int day;

            public void Print()
            {
                Console.WriteLine("{0} {1}, {2}", month, day, year);
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
                28, // February; 29 if leap year
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

        private static int GetInputYear()
        {
            while (true)
            {
                Console.Write("Input a year: ");
                string input = Console.ReadLine();
                try
                {
                    int num = Convert.ToInt32(input);
                    if (num < 0)
                    {
                        throw new InvalidArgumentException(
                            "Invalid input. Year cannot be negative.");
                    }
                    // Valid input
                    return num;
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
                catch (InvalidArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Assumes every year divisible by 4 is a leap year.
        // In reality this is not true, but suffices for the 21st century.
        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0);
        }

        private static int GetInputNumber(int year)
        {
            // Account for leap years
            bool isLeapYear = IsLeapYear(year);
            int maxDays = (isLeapYear) ? 366 : 365;

            while (true)
            {
                Console.Write("Input an integer between 1 and {0}: ", maxDays);
                string input = Console.ReadLine();
                try
                {
                    int num = Convert.ToInt32(input);
                    if (num < 1 || num > maxDays)
                    {
                        string errMsg = string.Format(
                            "Invalid input. Number must be between 1 and {0}.",
                            maxDays);
                        throw new InvalidArgumentException(errMsg);
                    }
                    // Valid input
                    return num;
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
                catch (InvalidArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Date GetDate(int num, int year)
        {
            bool isLeapYear = IsLeapYear(year);
            int m = 0; // Month index
            foreach(int numDays in daysPerMonth)
            {
                // Adjust for leap year February
                int adjNumDays = numDays;
                if (isLeapYear && m == 1)
                {
                    adjNumDays++;
                }
                if (num <= adjNumDays)
                {
                    // num falls in this month
                    break;
                }
                else
                {
                    // num falls in a later month
                    num -= adjNumDays;
                    m++;
                }
            }
            return new Date() { year = year, month = months[m], day = num };
        }

        static void Main(string[] args)
        {
            // Get year from user
            int year = GetInputYear();
            // Get day number from user
            int num = GetInputNumber(year);

            // Get month and day
            Date date = GetDate(num, year);
            date.Print();
        }
    }
}
