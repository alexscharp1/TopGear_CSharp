using System;

namespace ClassesAndStructs4
{
    class Employee : Person
    {
        private int yearStarted;
        private decimal salary;
        private string insuranceNumber;

        // Main Constructor. Overloaded by others.
        public Employee(string name, int yearStarted, decimal salary,
            string insuranceNumber)
            : base(name)
        {
            this.yearStarted = yearStarted;
            this.salary = salary;
            this.insuranceNumber = insuranceNumber;
        }

        public Employee(string name, int yearStarted)
            : this(name, yearStarted, 0, "") { }

        public Employee(string name, int yearStarted, decimal salary)
            : this(name, yearStarted, salary, "") { }

        public Employee(string name, int yearStarted, string insuranceNumber)
            : this(name, yearStarted, 0, insuranceNumber) { }


        // Properties of private fields
        public int YearStarted
        {
            get { return yearStarted; }
            set
            {
                if (value > 0 && value < 10000)
                {
                    yearStarted = value;
                }
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                {
                    salary = value;
                }
            }
        }

        public string InsuranceNumber
        {
            get { return insuranceNumber; }
            set { insuranceNumber = value; }
        }

        public override string ToString()
        {
            string str = string.Format(
                "Name:\t\t{0}\nYear started:\t{1}\nSalary:\t\t{2:C}\n"
                + "NINO:\t\t{3}", Name, yearStarted, salary, insuranceNumber
                );

            return str;
        }
    }
}
