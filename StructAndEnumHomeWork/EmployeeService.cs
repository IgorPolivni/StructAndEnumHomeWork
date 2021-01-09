using System;
using System.Collections.Generic;
using System.Text;

namespace StructAndEnumHomeWork
{
    public class EmployeeService
    {
       
        public static int NumberEmployee(Employee[] employees, Vacancies vacancy)
        {
            int numberEmployee = new int();
            foreach (Employee employee in employees)
            {
                if (employee.Vacancy == vacancy)
                    numberEmployee++;
            }
            return numberEmployee;
        }

        public static Employee[] FindEmployees(Employee[] employees, Vacancies vacancy)
        {
            int numberEmployees = NumberEmployee(employees, vacancy);
            Employee[] newEmployees = new Employee[numberEmployees];
            int count = new int();
            foreach(Employee employee in employees)
            {
                if (employee.Vacancy == vacancy)
                {
                    newEmployees[count] = employee;
                    count++;
                }
                if (count == numberEmployees)
                    break;
            }
            return newEmployees;
        }
        public static void managersWithSalariesHigherAverageClerksSalary()
        {

        }

        //Расчет средней зарпаты 
        public static int CalculatingAverageSalary(Employee[] employees, Vacancies vacancy)
        {
            int totalSalary = new int(), numberEmployees = new int(), AverageSalary = new int();

            foreach (Employee employee in employees)
            {
                if (employee.Vacancy == vacancy)
                {
                    totalSalary += employee.Salary;
                    numberEmployees++;
                }
            }
            if (numberEmployees != 0)
                AverageSalary = totalSalary / numberEmployees;
            return AverageSalary;
        }
        private static bool IsOrder(string firstStr, string secondStr)
        {
            int minStr = new int();
            if (firstStr.Length < secondStr.Length) minStr = firstStr.Length;
            else  minStr = secondStr.Length;

            for (int i = 0; i < minStr; i++)
            {
                if (firstStr[i] < secondStr[i]) return true;
                if (firstStr[i] > secondStr[i]) return false;
            }
            return true;
        }

        public static void SortByName(ref Employee[] employees)
        {
            if (employees.Length > 0) 
            {
                int count = new int();
                do
                {
                    count = new int();
                    for (int i = 0; i < employees.Length - 1; i++)
                    {
                        if (!IsOrder(employees[i].Name, employees[i+1].Name))
                        {
                            Employee temp = employees[i];
                            employees[i] = employees[i + 1];
                            employees[i + 1] = temp;
                            count++;
                        }
                    }
                } while (count != 0);
            }
        }

        public static Employee[] EmployeesWithLessExperience(Employee[] employees, Employee employee)
        {
            int counter = new int();
            foreach (Employee employeeFromArray in employees)
            {
                if (IsLessExperience(employee, employeeFromArray))
                    counter++;
            }
            Employee[] newEmployees = new Employee[counter];
            for (int i = 0,j=0;i< employees.Length; i++)
            {
                if (IsLessExperience(employee,employees[i]))
                {
                    newEmployees[j] = employees[i];
                    j++;
                }
            }
            return newEmployees;
        }

        public static bool IsLessExperience(Employee firstEmployee, Employee secondEmployee)
        {
            if (firstEmployee.EmploymentDate < secondEmployee.EmploymentDate)
                return true;
            else
                return false;
        }


        public static Employee SelectEmployee(Employee[] employees)
        {
            Employee selectedEmployee = new Employee();
            if (employees.Length > 1)
            {
                Menu.PrintAllEmployeeWithIndex(employees);
                int index = Menu.SelectIndex(employees.Length);
                selectedEmployee = employees[index];
            }
            else if (employees.Length == 1)
                selectedEmployee = employees[0];
            else
                throw new ArgumentException();
            return selectedEmployee;
        }


    }
}
