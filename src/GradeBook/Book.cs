using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<Double> grades;
        // List<Grade> courseGrade;
        public string Name;

        public Book(string name)
        {
            this.Name = name;
            this.grades = new List<double>();
            // this.courseGrade = new List<Grade>();
        }
        public void addGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
            }
            else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    addGrade(90);
                    break;
                case 'B':
                    addGrade(80);
                    break;
                case 'C':
                    addGrade(70);
                    break;
                case 'D':
                    addGrade(60);
                    break;
                default:
                    addGrade(0);
                    break;    
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
            if(this.grades.Count == 0) return 0.0;
            var min = double.MaxValue;
            this.grades.ForEach(grade =>
            {
                min = Math.Min(min, grade);
            });

            return min;
        }

        public double getMaxGrade()
        {
            if(this.grades.Count == 0) return 0.0;
            
            var max = double.MinValue;
            this.grades.ForEach(grade =>
            {
                max = Math.Max(max, grade);
            });

            return max;
        }
        public Statistics getStatistics() {
            double avg = this.getAverageGrade();
            double high = this.getMaxGrade();
            double min = this.getMinGrade();
            char Letter;
            switch(avg)
            {
                case var d when d >= 90.0:
                    Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    Letter = 'D';
                    break;
                default:
                    Letter = 'F';
                    break;
            }
            return new Statistics(avg, high, min, Letter);
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