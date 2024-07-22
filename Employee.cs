using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1IshratVohra
{

    public enum EmployeeType
    {
        CommissionEmployee, HourlyEmployee, SalariedEmployee, SalaryPlusCommissionEmployee
    }

    public abstract class Employee
    {

        private static int employeeCounter = 1;
        private int _empId;
        private EmployeeType _empType;
        private string _name;

        public int EmployeeId
        {
            get { return _empId; }
            private set { _empId = value; }
        }

        public EmployeeType TypeOfEmployee
        {
            get { return _empType; }
            private set { _empType = value; }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }


        public Employee( EmployeeType empType, string name)
        {
            _empId = employeeCounter++;
            _empType = empType;
            _name = name;

        }

       


        public abstract double GrossEarning { get; }

        public double Tax { get => GrossEarning * 0.20; }

        public double NetEarning{ get => GrossEarning - Tax; }

        public override string ToString()
        {
            return $"{_empId,-5} {_name,-10} {_empType,-10} {GrossEarning,-10:C} {Tax,-10:C} {NetEarning,-10:C}";
        }

    }
}
