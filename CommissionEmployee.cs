using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1IshratVohra
{
    public class CommissionEmployee :Employee
    {

        private double _grossSale;
        private double _commRate;

        public double GrossSales
        {
            get { return _grossSale; }

           set
            {
                _grossSale = value;
            }
        }

        public double CommRate
        {
            get { return _commRate; }

            set
            {
                _commRate = value;
            }
        }

        public CommissionEmployee(EmployeeType empType,string name,double grossSale, double commRate) : base(empType, name)
        {     
            _grossSale = grossSale;
            _commRate = commRate;
        }

        public override double GrossEarning
        {
            get
            { 
            return _grossSale * _commRate;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" {_grossSale,-10:C} {_commRate, -10:P}";
        }
    }
}
