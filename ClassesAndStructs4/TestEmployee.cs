using System;
using System.Text;

/* Fully test the Employee class definition */

namespace ClassesAndStructs4
{
    class TestEmployee
    {
        static void Main(string[] args)
        {
            // Build error report with stringbuilder
            StringBuilder sb = new StringBuilder();

            // Multiple constructors possible
            Employee emp1 = new Employee("Harry Potter", 2018);
            Employee emp2 = new Employee("Ginny Weasley", 2019, 60000);
            Employee emp3 = new Employee("Draco Malfoy", 2016, "QQ123456C");
            Employee emp4 = new Employee("Luna Lovegood", 2019, 75000, "QQ987654C");

            // Check that constructors worked properly (and use Getters)
            if (emp1.Name != "Harry Potter" || emp1.YearStarted != 2018
                || emp1.Salary != 0 || emp1.InsuranceNumber != "")
            {
                sb.AppendLine(string.Format(
                    "Constructor test 1 failed. Emp1:\n{0}", emp1.ToString()));
            }
            else
            {
                sb.AppendLine("Constructor test 1 passed.");
            }

            if (emp2.Name != "Ginny Weasley" || emp2.YearStarted != 2019
                || emp2.Salary != 60000 || emp2.InsuranceNumber != "")
            {
                sb.AppendLine(string.Format(
                    "Constructor test 2 failed. Emp2:\n{0}", emp2.ToString()));
            }
            else
            {
                sb.AppendLine("Constructor test 2 passed.");
            }

            if (emp3.Name != "Draco Malfoy" || emp3.YearStarted != 2016
                || emp3.Salary != 0 || emp3.InsuranceNumber != "QQ123456C")
            {
                sb.AppendLine(string.Format(
                    "Constructor test 3 failed. Emp3:\n{0}", emp3.ToString()));
            }
            else
            {
                sb.AppendLine("Constructor test 3 passed.");
            }

            if (emp4.Name != "Luna Lovegood" || emp4.YearStarted != 2019
                || emp4.Salary != 75000 || emp4.InsuranceNumber != "QQ987654C")
            {
                sb.AppendLine(string.Format(
                    "Constructor test 4 failed. Emp4: \n{0}", emp4.ToString()));
            }
            else
            {
                sb.AppendLine("Constructor test 4 passed.");
            }

            // Use setters and test them
            emp1.Name = "Neville Longbottom";
            if (emp1.Name != "Neville Longbottom")
            {
                sb.AppendLine(string.Format(
                    "Setter test 1 failed. Emp1.Name: {0}", emp1.Name));
            }
            else
            {
                sb.AppendLine("Setter test 1 passed.");
            }

            emp1.YearStarted = 2019;
            if (emp1.YearStarted != 2019)
            {
                sb.AppendLine(string.Format(
                    "Setter test 2 failed. Emp1.YearStarted: {0}",
                    emp1.YearStarted));
            }
            else
            {
                sb.AppendLine("Setter test 2 passed.");
            }

            emp1.Salary = 65000;
            if (emp1.Salary != 65000)
            {
                sb.AppendLine(string.Format(
                    "Setter test 3 failed. Emp1.Salary: {0}", emp1.Salary));
            }
            else
            {
                sb.AppendLine("Setter test 3 passed.");
            }

            emp1.InsuranceNumber = "QQ777777C";
            if (emp1.InsuranceNumber != "QQ777777C")
            {
                sb.AppendLine(string.Format(
                    "Setter test 4 failed. Emp1.InsuranceNumber: {0}", 
                    emp1.InsuranceNumber));
            }
            else
            {
                sb.AppendLine("Setter test 4 passed.");
            }

            // Print any errors, or a message if none occured
            Console.WriteLine(sb.ToString());
        }
    }
}
