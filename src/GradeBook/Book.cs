using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        List<Double> grades;
        // List<Grade> courseGrade;
        string name;

        public Book(string name)
        {
            this.name = name;
            this.grades = new List<double>();
            // this.courseGrade = new List<Grade>();
        }
        public void addGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
            }
        }
        public int getGradeCount()
        {
            return this.grades.Count;
        }

        public double getAverageGrade()
        {
            var total = 0.0;
            int count = getGradeCount();
            if (count == 0)
            {
                return 0.0;
            }
            this.grades.ForEach(grade =>
            {
                total += grade;
            });
            return total / count;
        }

        public double getMinGrade()
        {
            var min = double.MaxValue;
            this.grades.ForEach(grade =>
            {
                min = Math.Min(min, grade);
            });

            return min;
        }

        public double getMaxGrade()
        {
            var max = double.MinValue;
            this.grades.ForEach(grade =>
            {
                max = Math.Max(max, grade);
            });

            return max;
        }

        public void showStatistic() {
            Console.WriteLine($"The average grade is : {this.getAverageGrade():n2}");
            Console.WriteLine($"The max grade is : {this.getMaxGrade():n2}");
            Console.WriteLine($"The min grade is : {this.getMinGrade():n2}");
        }

    }

    class Grade {
        double grade;
        string course;

        public Grade(String course, double grade) {
            this.grade = grade;
            this.course = course;
        }
    }
}