using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace A1IshratVohra
{
    public class HourlyEmployee : Employee
    {   
        private int _hrsWorked;
        private double _hourlyWage;

        public int HrsWorked
        {
            get { return _hrsWorked; }
            set
            {
                _hrsWorked = value;
            }
        }

        public double HourlyWage
        {
            get { return _hourlyWage; }
            set
            {
                _hourlyWage = value;
            }
        }
        public HourlyEmployee(EmployeeType empType, string name,int hrsWorked, double hourlyWage): base(empType,name){ 
            _hrsWorked = hrsWorked;
            _hourlyWage = hourlyWage;
        }


        public override double GrossEarning
        {

            get
            {
                if(_hrsWorked <= 0) {
                    return _hrsWorked * _hourlyWage;
                }
                else
                {
                    return (40 * _hourlyWage) + ((_hrsWorked - 40) * _hourlyWage * 1.5);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" {_hrsWorked,-10} {_hourlyWage,-10:C}";
        }
    }
}
