using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1IshratVohra
{
    internal class SalariedEmployee : Employee
    {
        private double _wklySalary;

        public double WklySalary
        {
            get { return _wklySalary; }
            set
            {
                _wklySalary = value;
            }
        }

        public SalariedEmployee(EmployeeType empType, string name, double wklySalary) : base(empType, name)
        {
            _wklySalary = wklySalary;
        }

        public override double GrossEarning
        {
            get { 
            return _wklySalary;
            }
        }

        public override string ToString()
        {
            return $"Salaried Emp: {base.ToString()}" +
                $"\nWeekly Salary: {_wklySalary:C}";
        }

    }
}
