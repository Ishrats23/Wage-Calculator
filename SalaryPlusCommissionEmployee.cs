using A1IshratVohra;

public class SalaryPlusCommissionEmployee : CommissionEmployee
{
    private double _salary;
    public double Salary
    {
        get { return _salary; }
        set
        {
            if (value < 0)
                throw new Exception("Base salary cannot be < 0");
            else
                _salary = value;
        }
    }

    public SalaryPlusCommissionEmployee(EmployeeType empType, string name, double salary, double grossSale, double commRate)
        : base(empType, name, grossSale, commRate)
    {
        _salary = salary;
    }

    public override double GrossEarning
    {
        get
        {
            return _salary + base.GrossEarning;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {_salary:C}";
    }
}
