using System;
using System.Collections.Generic;
using System.Text;

namespace StructAndEnumHomeWork
{
    public class Menu
    {
        public static void PrintEmployeeInfo(Employee employee)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Имя работника: {employee.Name}");
            Console.WriteLine($"Дожность: {employee.Vacancy}");
            Console.WriteLine($"Зарплата: {employee.Salary}");
            Console.Write($"Дата приема на работу: {employee.EmploymentDate.ToShortDateString()}\n");
        }


        public static int SelectIndex(int lengthArray)
        {
            int index = new int();
            do
            {
                Console.WriteLine("Введите индекс: ");
                if (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= lengthArray)
                    index = -1;
            } while (index == -1);

            return index;
        }


        public static void PrintAllEmployeeWithIndex(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"\nНомер сотрудника №{i}");
                PrintEmployeeInfo(employees[i]);
            }
        }

        public static void PrintStudentInfo(Student student)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Ф.И.О. студента: {student.FullName}");
            Console.WriteLine($"Название группы: {student.GroupName}");
            Console.WriteLine($"Средний балл: {student.AverageScore}");
            Console.WriteLine($"Доход на члена семьи: {student.IncomePerFamilyMember}");
            Console.WriteLine($"Пол студента: {student.StudentGender}");
            Console.WriteLine($"Форма обучения: {student.StudentTrainingForm}");

        }

        public static int PrintVacancies()
        {
            var names = Enum.GetNames(typeof(Vacancies));
            int counter = new int();
            foreach(string name in names)
            {
                Console.WriteLine($"{counter}. {name}");
                counter++;
            }
            return counter;
        }

        public static Employee[] FillEmployeesArray(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Console.Clear();
                Console.Write("Введите имя сотрудника: ");
                employees[i].Name = Console.ReadLine();
                int numberVacancies = PrintVacancies();
                Console.Write("Введите номер должности: ");
                int.TryParse(Console.ReadLine(), out int index);
                if (index > numberVacancies || index < 0)
                    index = 0;
                employees[i].Vacancy = (Vacancies)index;
                Console.Write("Введите зарплату: ");
                int.TryParse(Console.ReadLine(), out int value);
                if (value < 0) value = 0;
                employees[i].Salary = value;
                Console.WriteLine("Введите дату приема на работу:");
                Console.Write("Введите год: ");
                int.TryParse(Console.ReadLine(), out int year);
                if (year <= 0) year = 2000;
                Console.Write("Введите месяц: ");
                int.TryParse(Console.ReadLine(), out int month);
                if (month <= 0 || month > 12) month = 1;
                Console.Write("Введите день: ");
                int.TryParse(Console.ReadLine(), out int day);
                if (day <= 0 || day > 31) day = 1;
                employees[i].EmploymentDate = new DateTime(year, month, day);
                Console.Clear();

            }
            return employees;
        }

    }
}
