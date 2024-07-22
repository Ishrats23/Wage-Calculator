using System;
using System.Collections.Generic;
using ConsoleTables;


namespace A1IshratVohra
{
    internal class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            employees.AddRange(new List<Employee>
            {
                new HourlyEmployee(EmployeeType.HourlyEmployee,"Joe",35,15.0),
                new HourlyEmployee(EmployeeType.HourlyEmployee,"Mike",20,16.55),
                new SalariedEmployee(EmployeeType.SalariedEmployee,"Harjinder",500),
                new SalariedEmployee(EmployeeType.SalariedEmployee,"Michael",700),
                new CommissionEmployee(EmployeeType.CommissionEmployee,"Ira",1000,0.15),
                new CommissionEmployee(EmployeeType.CommissionEmployee,"Priti",3000,0.25),
                new SalaryPlusCommissionEmployee(EmployeeType.SalaryPlusCommissionEmployee,"Parth",500,2000,0.40),
                new SalaryPlusCommissionEmployee(EmployeeType.SalaryPlusCommissionEmployee,"Ami",2000,6000,0.60)
            });

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddEmp();
                        break;
                    case "2":
                        EditEmp();
                        break;
                    case "3":
                        DeleteEmp();
                        break;
                    case "4":
                        ViewEmp();
                        break;
                    case "5":
                        SearchEmp();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Add Employee");
            Console.WriteLine("2 - Edit Employee");
            Console.WriteLine("3 - Delete Employee");
            Console.WriteLine("4 - View Employee");
            Console.WriteLine("5 - Search Employee");
            Console.WriteLine("6 - Exit");
            Console.Write("Enter Number (1-6): ");
        }

        static void AddEmp()
        {
            Console.WriteLine("Choose the type of employee from the option:");
            Console.WriteLine("1 - Hourly Employee");
            Console.WriteLine("2 - Salaried Employee");
            Console.WriteLine("3 - Commission Employee");
            Console.WriteLine("4 - Salary Plus Commission Employee");
            Console.WriteLine("5 - Back to Main Menu");
            Console.Write("Enter Number(1-5):  ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddHourlyEmp();
                    break;
                case "2":
                    AddSalariedEmp();
                    break;
                case "3":
                    AddCommEmp();
                    break;
                case "4":
                    AddSalaryPlusCommEmp();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid! Choose Again.");
                    break;
            }
        }

        static void AddHourlyEmp()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter hours worked: ");
            double hrsWorked = double.Parse(Console.ReadLine());
            Console.Write("Enter hourly rate: ");
            double hourlyRate = double.Parse(Console.ReadLine());
            HourlyEmployee newEmployee = new HourlyEmployee(EmployeeType.HourlyEmployee, name, (int)hrsWorked, hourlyRate);
            employees.Add(newEmployee);
            Console.WriteLine("\nHourly Employee added\nTable Updated:");
            ViewEmpByType(typeof(HourlyEmployee));
        }

        static void AddSalariedEmp()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter weekly salary: ");
            double weeklySalary = double.Parse(Console.ReadLine());
            SalariedEmployee newEmployee = new SalariedEmployee(EmployeeType.SalariedEmployee, name, weeklySalary);
            employees.Add(newEmployee);
            Console.WriteLine("\nSalaried Employee Added\nTable Updated");
            ViewEmpByType(typeof(SalariedEmployee));
        }

        static void AddCommEmp()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Gross Sales: ");
            double grossSale = double.Parse(Console.ReadLine());
            Console.Write("Enter Commission Rate: ");
            double commRate = double.Parse(Console.ReadLine());
            CommissionEmployee newEmployee = new CommissionEmployee(EmployeeType.CommissionEmployee, name, grossSale, commRate / 100);
            employees.Add(newEmployee);
            Console.WriteLine("\nCommission Employee Added\nTable Updated");
            ViewEmpByType(typeof(CommissionEmployee));
        }

        static void AddSalaryPlusCommEmp()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Salary: ");
            double baseSalary = double.Parse(Console.ReadLine());
            Console.Write("Enter Gross Sales: ");
            double grossSale = double.Parse(Console.ReadLine());
            Console.Write("Enter Commission Rate: ");
            double commRate = double.Parse(Console.ReadLine());
            SalaryPlusCommissionEmployee newEmployee = new SalaryPlusCommissionEmployee(EmployeeType.SalaryPlusCommissionEmployee, name, baseSalary, grossSale, commRate / 100);
            employees.Add(newEmployee);
            Console.WriteLine("\nSalary Plus Commission Employee added\n Table Updated:");
            ViewEmpByType(typeof(SalaryPlusCommissionEmployee));
        }

        static void EditEmp()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Nothing to edit.");
                return;
            }

            Console.WriteLine("Choose the type of employee to edit:");
            Console.WriteLine("1 - Hourly Emp");
            Console.WriteLine("2 - Salaried Emp");
            Console.WriteLine("3 - Commission Emp");
            Console.WriteLine("4 - Salary Plus Commission Emp");
            Console.Write("Enter Number(1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {


                case "1":
                    ViewEmpByType(typeof(HourlyEmployee));
                    EditEmpById(typeof(HourlyEmployee));
                    ViewEmpByType(typeof(HourlyEmployee));
                    break;
                case "2":
                    ViewEmpByType(typeof(SalariedEmployee));
                    EditEmpById(typeof(SalariedEmployee));
                    ViewEmpByType(typeof(SalariedEmployee));
                    break;
                case "3":
                    ViewEmpByType(typeof(CommissionEmployee));
                    EditEmpById(typeof(CommissionEmployee));
                    ViewEmpByType(typeof(CommissionEmployee));
                    break;
                case "4":
                    ViewEmpByType(typeof(SalaryPlusCommissionEmployee));
                    EditEmpById(typeof(SalaryPlusCommissionEmployee));
                    ViewEmpByType(typeof(SalaryPlusCommissionEmployee));
                    break;
                default:
                    Console.WriteLine("Invalid! Choose Again.");
                    break;
            }
        }

        static void EditEmpById(Type type)
        {
            Console.Write($"Enter the ID of {type.Name}, you want to edit: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = employees.Find(emp => emp.EmployeeId == id && emp.GetType() == type);
            if (employee == null)
            {
                Console.WriteLine($"No {type.Name} found with id : {id}.");
                return;
            }

            Console.WriteLine($"Editing {type.Name} with id : {id}:");
            if (employee is HourlyEmployee hourlyEmp)
            {
                Console.Write("Enter new hours: ");
                hourlyEmp.HrsWorked = int.Parse(Console.ReadLine());
                Console.Write("Enter new hourly rate: ");
                hourlyEmp.HourlyWage = double.Parse(Console.ReadLine());
            }
            else if (employee is SalariedEmployee salariedEmp)
            {
                Console.Write("Enter new weekly salary: ");
                salariedEmp.WklySalary = double.Parse(Console.ReadLine());
            }
            else if (employee is CommissionEmployee commissionEmp)
            {
                Console.Write("Enter new gross sales: ");
                commissionEmp.GrossSales = double.Parse(Console.ReadLine());
                Console.Write("Enter new commission rate : ");
                commissionEmp.CommRate = double.Parse(Console.ReadLine()) / 100;
            }
            else if (employee is SalaryPlusCommissionEmployee salaryPlusCommEmp)
            {
                Console.Write("Enter new gross sales: ");
                salaryPlusCommEmp.GrossSales = double.Parse(Console.ReadLine());
                Console.Write("Enter new commission rate : ");
                salaryPlusCommEmp.CommRate = double.Parse(Console.ReadLine()) / 100;
                Console.Write("Enter new salary ");
                salaryPlusCommEmp.Salary = double.Parse(Console.ReadLine());
            }
        }

        static void DeleteEmp()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Nothing to delete.");
                return;
            }

            Console.WriteLine("Choose the type of employee to delete:");
            Console.WriteLine("1 - Hourly Emp");
            Console.WriteLine("2 - Salaried Emp");
            Console.WriteLine("3 - Commission Emp");
            Console.WriteLine("4 - Salary Plus Commission Emp");
            Console.Write("Enter Number(1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewEmpByType(typeof(HourlyEmployee));
                    DeleteEmpById(typeof(HourlyEmployee));
                    break;
                case "2":
                    ViewEmpByType(typeof(SalariedEmployee));
                    DeleteEmpById(typeof(SalariedEmployee));
                    break;
                case "3":
                    ViewEmpByType(typeof(CommissionEmployee));
                    DeleteEmpById(typeof(CommissionEmployee));
                    break;
                case "4":
                    ViewEmpByType(typeof(SalaryPlusCommissionEmployee));
                    DeleteEmpById(typeof(SalaryPlusCommissionEmployee));
                    break;
                default:
                    Console.WriteLine("Invalid! Choose Again");
                    break;
            }
        }

        static void DeleteEmpById(Type type)
        {
            int id = GetEmployeeIdToDelete(type);
            Employee employeeToRemove = FindEmpByIdAndType(id, type);
            if (employeeToRemove == null)
            {
                Console.WriteLine($"No {type.Name} found with id: {id}.");
                return;
            }
            RemoveEmployee(employeeToRemove);
            Console.WriteLine($"\nEmp with ID {id} deleted\n Table Updated");
            ViewEmpByType(type);
        }

        static int GetEmployeeIdToDelete(Type type)
        {
            Console.Write($"Enter the ID of the {type.Name} to delete: ");
            return int.Parse(Console.ReadLine());
        }

        static Employee FindEmpByIdAndType(int id, Type type)
        {
            return employees.Find(emp => emp.EmployeeId == id && emp.GetType() == type);
        }

        static void RemoveEmployee(Employee employeeToRemove)
        {
            employees.Remove(employeeToRemove);
        }


        static void ViewEmp()
        {
            Console.WriteLine("View All Employees:");
            if (employees.Count == 0)
            {
                Console.WriteLine("Nothing to display.");
                return;
            }

            ViewEmpByType(typeof(HourlyEmployee));
            ViewEmpByType(typeof(SalariedEmployee));
            ViewEmpByType(typeof(CommissionEmployee));
            ViewEmpByType(typeof(SalaryPlusCommissionEmployee));
        }

        static void ViewEmpByType(Type type)
        {
            List<Employee> employeesOfType = employees.FindAll(emp => emp.GetType() == type);
            if (employeesOfType.Count > 0)
            {
                PrintTableForEmployees(employeesOfType);
                Console.WriteLine();
            }
        }

        static void SearchEmp()
        {
            Console.Write("Enter a name or part to search: ");
            string searchName = Console.ReadLine().ToLower();

            List<Employee> searchResults = employees.FindAll(emp => emp.Name.ToLower().Contains(searchName));
            if (searchResults.Count == 0)
            {
                Console.WriteLine("No matching employees found.");
                return;
            }

            Console.WriteLine("Matching Emp:");
            PrintTableForEmployees(searchResults);
        }

        static void PrintTableForEmployees(List<Employee> employees)
        {
            var hourlyEmp = new List<HourlyEmployee>();
            var salariedEmp = new List<SalariedEmployee>();
            var commissionEmp = new List<CommissionEmployee>();
            var salaryPlusCommEmp = new List<SalaryPlusCommissionEmployee>();

            foreach (var employee in employees)
            {
                if (employee is HourlyEmployee hourly)
                {
                    hourlyEmp.Add(hourly);
                }
                else if (employee is SalariedEmployee salaried)
                {
                    salariedEmp.Add(salaried);
                }
                else if (employee is SalaryPlusCommissionEmployee salaryPlusComm)
                {
                    salaryPlusCommEmp.Add(salaryPlusComm);
                }
                else if (employee is CommissionEmployee commission)
                {
                    commissionEmp.Add(commission);
                }
            }

            if (hourlyEmp.Count > 0)
            {
                Console.WriteLine("\n *** Hourly Employee ***");
                var hourlyTable = new ConsoleTable("Emp ID", "Name", "Hours Worked", "Hourly Wage", "Gross Earnings", "Tax", "Net Earnings");

                foreach (var employee in hourlyEmp)
                {
                    hourlyTable.AddRow(employee.EmployeeId, employee.Name, employee.HrsWorked, $"{employee.HourlyWage:C}", $"{employee.GrossEarning:C}", $"{employee.Tax:C}", $"{employee.NetEarning:C}");
                }

                hourlyTable.Write();
                Console.WriteLine();
            }

            if (salariedEmp.Count > 0)
            {
                Console.WriteLine("\n *** Salaried Employee *** ");
                var salariedTable = new ConsoleTable("Emp ID", "Name", "Weekly Salary", "Gross Earnings", "Tax", "Net Earnings");

                foreach (var employee in salariedEmp)
                {
                    salariedTable.AddRow(employee.EmployeeId, employee.Name, $"{employee.WklySalary:C}", $"{employee.GrossEarning:C}", $"{employee.Tax:C}", $"{employee.NetEarning:C}");
                }

                salariedTable.Write();
                Console.WriteLine();
            }

            if (commissionEmp.Count > 0)
            {
                Console.WriteLine("\n *** Commission Employee *** ");
                var commissionTable = new ConsoleTable("Emp ID", "Name", "Gross Sales", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                foreach (var employee in commissionEmp)
                {
                    commissionTable.AddRow(employee.EmployeeId, employee.Name, $"{employee.GrossSales:C}", $"{employee.CommRate:P}", $"{employee.GrossEarning:C}", $"{employee.Tax:C}", $"{employee.NetEarning:C}");
                }

                commissionTable.Write();
                Console.WriteLine();
            }

            if (salaryPlusCommEmp.Count > 0)
            {
                Console.WriteLine("\n *** Salary Plus Commission Employee *** ");
                var salaryPlusCommissionTable = new ConsoleTable("Emp ID", "Name", "Salary", "Gross Sales", "Commission Rate", "Gross Earnings", "Tax", "Net Earnings");

                foreach (var employee in salaryPlusCommEmp)
                {
                    salaryPlusCommissionTable.AddRow(employee.EmployeeId, employee.Name, $"{employee.Salary:C}", $"{employee.GrossSales:C}", $"{employee.CommRate:P}", $"{employee.GrossEarning:C}", $"{employee.Tax:C}", $"{employee.NetEarning:C}");
                }

                salaryPlusCommissionTable.Write();
                Console.WriteLine();
            }
        }
    }
}


