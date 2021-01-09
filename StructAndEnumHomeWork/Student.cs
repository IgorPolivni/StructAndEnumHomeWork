using System;
using System.Collections.Generic;
using System.Text;

namespace StructAndEnumHomeWork
{
    public struct Student
    {
        public string FullName { get; set; }

        public string GroupName { get; set; }

        //Средний балл
        public double AverageScore { get; set; }
        
        //Доход на члена семьи
        public int IncomePerFamilyMember { get; set; }

        //Пол
        public Gender StudentGender { get; set; }

        //Форма обучения
        public TrainingForm StudentTrainingForm { get; set; }

        public static bool operator >(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.AverageScore > secondStudent.AverageScore) return true;
            else return false;
        }
        public static bool operator <(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.AverageScore < secondStudent.AverageScore) return true;
            else return false;
        }
    }
}
