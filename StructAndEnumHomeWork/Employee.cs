using System;
using System.Collections.Generic;
using System.Text;

namespace StructAndEnumHomeWork
{
    public struct Employee
    {
        public string Name { get; set; }
        public Vacancies Vacancy { get; set; }
        public int Salary { get; set; }

        //Дата приема на работу 
        public DateTime EmploymentDate { get; set; }
    }
}
