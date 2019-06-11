using System;

/* Employee objecct to contain name and salary info */

namespace ClassesAndStructs1
{
    class Employee
    {

        private string name;
        private decimal baseSalary, hra, da, tax, grossPay, netPay;

        public Employee(string name, decimal salary)
        {
            this.name = name;
            baseSalary = salary;
            CalculateNetPay();
        }

        public void CalculateNetPay()
        {
            hra = baseSalary * (decimal)0.15;
            da = baseSalary * (decimal)0.1;
            grossPay = baseSalary + hra + da;
            tax = grossPay * (decimal)0.08;
            netPay = grossPay - tax;
        }

        public void Display()
        {
            Console.WriteLine("***EMPLOYEE DETAILS***");
            Console.WriteLine("Employee name:\t{0, 20}", name);
            Console.WriteLine("Base salary:\t{0, 20:C2}", baseSalary);
            Console.WriteLine("HRA:\t\t{0, 20:C2}", hra);
            Console.WriteLine("DA:\t\t{0, 20:C2}", da);
            Console.WriteLine("Gross Pay:\t{0, 20:C2}", grossPay);
            Console.WriteLine("Tax:\t\t{0, 20:C2}", tax);
            Console.WriteLine("Net pay:\t{0, 20:C2}", netPay);
        }
    }
}
