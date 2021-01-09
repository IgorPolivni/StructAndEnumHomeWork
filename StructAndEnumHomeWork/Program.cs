using System;

namespace StructAndEnumHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            //--------------------------------------------
            //Сотрудники были создана для быстрой проверки
            //--------------------------------------------


            //Employee fManager = new Employee
            //{
            //    Name = "Дмитрий",
            //    Vacancy = Vacancies.Manager,
            //    EmploymentDate = new DateTime(2001, 09, 10),
            //    Salary = 200000
            //};
            //Employee sManager = new Employee
            //{
            //    Name = "Андрей",
            //    Vacancy = Vacancies.Manager,
            //    EmploymentDate = new DateTime(2001, 09, 30),
            //    Salary = 300000
            //};
            //Employee tManager = new Employee
            //{
            //    Name = "Валерий",
            //    Vacancy = Vacancies.Manager,
            //    EmploymentDate = new DateTime(2001, 09, 20),
            //    Salary = 400000
            //};
            //Employee fBoss = new Employee
            //{
            //    Name = "Анастасия",
            //    Vacancy = Vacancies.Boss,
            //    EmploymentDate = new DateTime(2010, 10, 20),
            //    Salary = 500000
            //};
            //Employee clerk = new Employee
            //{
            //    Name = "Владимир",
            //    Vacancy = Vacancies.Clerk,
            //    EmploymentDate = new DateTime(2012, 10, 20),
            //    Salary = 120000
            //};
            //Employee salesman = new Employee
            //{
            //    Name = "Валерия",
            //    Vacancy = Vacancies.Salesman,
            //    EmploymentDate = new DateTime(2014, 06, 26),
            //    Salary = 150000
            //};


            //const int sizeArray = 6;
            //Employee[] employees = new Employee[sizeArray]
            //{
            //    fManager,fBoss,clerk,salesman,sManager, tManager
            //};

            int sizeArray = new int();
            do
            {
                Console.Write("Введите длину массива работников: ");
                int.TryParse(Console.ReadLine(), out sizeArray);
                if (sizeArray<0)
                    Console.WriteLine("Вы ввели неправильное число!!!");
            } while (sizeArray <= 0);

            Employee[] employees = new Employee[sizeArray];
            employees = Menu.FillEmployeesArray(employees);

            //Вывод информации о всех сотрудниках
            Console.WriteLine("Вывод информации о всех сотрудниках:");
            Menu.PrintAllEmployeeWithIndex(employees);


            //найти в массиве всех менеджеров, зарплата которых больше средней 
            //зарплаты всех клерков, вывести на экран полную информацию о таких 
            //менеджерах отсортированной по их фамилии.
            int averageClerksSalary = EmployeeService.CalculatingAverageSalary(employees,Vacancies.Clerk);
            Employee[] managers = EmployeeService.FindEmployees(employees, Vacancies.Manager);
            if (managers.Length != 0 && averageClerksSalary!=0)
            {
                EmployeeService.SortByName(ref managers);
                Console.WriteLine($"\nСредняя зарплата Клерков = {averageClerksSalary}");
                Console.WriteLine("\nНайти в массиве всех менеджеров, зарплата которых больше средней зарплаты всех клерков");
                foreach (Employee employee in managers)
                {
                    if (employee.Salary > averageClerksSalary)
                        Menu.PrintEmployeeInfo(employee);
                }
            }
            else if (managers.Length == 0)
                Console.WriteLine("У вас на работе нет менеджеров!!!");
            else if (averageClerksSalary == 0)
                Console.WriteLine("У вас на работе нет Клерков или их средняя зарплата = 0!!!");

            //распечатать информацию обо всех сотрудниках, принятых на 
            //работу позже босса, отсортированную в алфавитном 
            //порядке по фамилии сотрудника.

            Console.WriteLine("\nВывод информации обо всех сотрудниках, принятых на работу позже босса:");
            Employee[] bosses = EmployeeService.FindEmployees(employees, Vacancies.Boss);
            if (bosses.Length != 0)
            {
                Employee boss = new Employee();
                boss = EmployeeService.SelectEmployee(bosses);

                Employee[] employeesWithLessExperienceThanBoss = EmployeeService.EmployeesWithLessExperience(employees, boss);
                EmployeeService.SortByName(ref employeesWithLessExperienceThanBoss);         
                Menu.PrintAllEmployeeWithIndex(employeesWithLessExperienceThanBoss);
            }
            else
            {
                Console.WriteLine("К счастью у вас на работе нет Боса!");
            }


            Console.ReadLine();
            Console.Clear();
            //Задание 2
            const int sizeStudentArray = 8;

            Student student_1 = new Student
            {
                FullName = "Поливин Игорь Игоревич",
                GroupName = "SET-201",
                AverageScore = 10.8,
                IncomePerFamilyMember = 50000,
                StudentGender = Gender.Male,
                StudentTrainingForm = TrainingForm.FullTime
            };

            Student student_2 = new Student
            {
                FullName = "Маслов Владимир Юрьевич",
                GroupName = "SET-202",
                AverageScore = 9.2,
                IncomePerFamilyMember = 70000,
                StudentGender = Gender.Male,
                StudentTrainingForm = TrainingForm.FullTime
            };

            Student student_3 = new Student
            {
                FullName = "Браташова Валерия Михайловна",
                GroupName = "SEP-306",
                AverageScore = 11.2,
                IncomePerFamilyMember = 100000,
                StudentGender = Gender.Female,
                StudentTrainingForm = TrainingForm.FullTime
            };

            Student student_4= new Student
            {
                FullName = "Пятунин Максив Владимирович",
                GroupName = "GAP-101",
                AverageScore = 8.2,
                IncomePerFamilyMember = 120000,
                StudentGender = Gender.Male,
                StudentTrainingForm = TrainingForm.PartTime
            };

            Student student_5 = new Student
            {
                FullName = "Ронковский Андрей Борисович",
                GroupName = "DEP-405",
                AverageScore = 7.1,
                IncomePerFamilyMember = 150000,
                StudentGender = Gender.Male,
                StudentTrainingForm = TrainingForm.PartTime
            };

            Student student_6 = new Student
            {
                FullName = "Мусинова Диана Максимовна",
                GroupName = "DEP-405",
                AverageScore = 6.3,
                IncomePerFamilyMember = 40000,
                StudentGender = Gender.Female,
                StudentTrainingForm = TrainingForm.FullTime
            };
            Student student_7 = new Student
            {
                FullName = "Мишина Елизовета Михайловна",
                GroupName = "DEP-408",
                AverageScore = 10.1,
                IncomePerFamilyMember = 100000,
                StudentGender = Gender.Female,
                StudentTrainingForm = TrainingForm.FullTime
            };

            Student student_8 = new Student
            {
                FullName = "Нурова Саёра Болатовна",
                GroupName = "SEP-408",
                AverageScore = 5.5,
                IncomePerFamilyMember = 40000,
                StudentGender = Gender.Female,
                StudentTrainingForm = TrainingForm.PartTime
            };


            Student[] students = new Student[sizeStudentArray]
            {
                student_1,student_2,student_3,student_4,
                student_5,student_6,student_7,student_8
            };

            Student[] sortedStudentsByPriority =  StudentService.CalculationHostelPlaces(students);

            Console.WriteLine("\n\n------------------------------------------");
            Console.WriteLine("--СТУДЕНТЫ ОТСОРТИРОВАННЫЕ ПО ПРИОРИТЕТУ--");
            Console.WriteLine("------------------------------------------");
            for(int i=0;i< sortedStudentsByPriority.Length;i++)
            {
                Console.WriteLine($"\nНомер студента {i+1}");
                Menu.PrintStudentInfo(sortedStudentsByPriority[i]);
            }

        }
    }
}
