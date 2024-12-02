using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    public class Student
    {
        public string Name { get; set; }
        public int[] Grades { get; set; } = new int[10];
        public string StudentClass { get; set; }

        // בנאי
        public Student(string name, int[] grades, string studentClass)
        {
            Name = name;
            Grades = grades;
            StudentClass = studentClass;
        }

        // פעולה לחישוב ממוצע ציונים
        public double CalculateAverage()
        {
            int sum = 0;
            foreach (int grade in Grades)
            {
                sum += grade;
            }
            return (double)sum / Grades.Length;
        }
    }

}
