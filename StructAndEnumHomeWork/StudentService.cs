using System;
using System.Collections.Generic;
using System.Text;

namespace StructAndEnumHomeWork
{
    public class StudentService
    {
        //Минимальная зарплата
        const int minimumWage = 42500;
        public static Student[] CalculationHostelPlaces(Student[] students)
        {
            //Получить льготных студентов
            students = SortByScore(students);
            Student[] preferentialStudents = GetPreferentialStudents(students);
            Student[] anotherStudents = StudentsExceptPreferential(students, preferentialStudents);
            students = new Student[students.Length];
            for (int i = 0;i< preferentialStudents.Length; i++)
                students[i] = preferentialStudents[i];
            for (int i = preferentialStudents.Length,j=0; i < students.Length; i++,j++)
                students[i] = anotherStudents[j];
            return students;

        }

        //
        public static Student[] StudentsExceptPreferential(Student[] students, Student[] preferentialStudents)
        {
            Student[] anotherStudents = new Student[students.Length - preferentialStudents.Length];
            bool thereIs = new bool();
            int counter = new int();
            for (int i = 0; i < students.Length; i++)
            {
                thereIs = false;
                for (int j = 0; j < preferentialStudents.Length; j++)
                {
                    if (students[i].Equals(preferentialStudents[j]))
                    {
                        thereIs = true;
                        break;
                    }
                }
                if (!thereIs)
                {
                    anotherStudents[counter] = students[i];
                    counter++;
                }
            }
            return anotherStudents;
        }


        public static Student[] GetPreferentialStudents(Student[] students) 
        {
            int numberPreferentialStudents = new int();
            foreach (Student student in students)
            {
                if (IsPreferentialStudent(student))
                    numberPreferentialStudents++;
            }
            Student[] preferentialStudents = new Student[numberPreferentialStudents];
            for (int i = 0, j = 0; i < students.Length; i++) 
            {
                if (IsPreferentialStudent(students[i]))
                {
                    preferentialStudents[j] = students[i];
                    j++;
                }
            }
            return preferentialStudents;
        }

        public static bool IsPreferentialStudent(Student student)
        {
            if (student.IncomePerFamilyMember < minimumWage * 2)
            {
                return true;
            }
            return false;
        }

        public static Student[] SortByScore(Student[] students)
        {
            if (students.Length > 1) {
                int counter = new int();
                do
                {
                    counter = new int();
                    for (int i = 0; i < students.Length - 1; i++)
                    {
                        if (students[i] < students[i + 1])
                        {
                            Student temp = students[i];
                            students[i] = students[i + 1];
                            students[i + 1] = temp;
                            counter++;
                        }
                    }

                } while (counter != 0);
            }
            return students;
        }



    }
}
