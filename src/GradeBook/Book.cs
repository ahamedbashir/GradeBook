using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            this.Name = name;
            this.grades = new List<double>();
        }

        public Book(string name, string category) : base(name) {
            this.Name = name;
            this.grades = new List<double>();
            this.category = category;
        }

        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;    
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public int GetGradeCount()
        {
            return this.grades.Count;
        }

        public double GetAverageGrade()
        {
            var total = 0.0;
            int count = GetGradeCount();
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

        public double GetMinGrade()
        {
            if(this.grades.Count == 0) return 0.0;
            var min = double.MaxValue;
            this.grades.ForEach(grade =>
            {
                min = Math.Min(min, grade);
            });

            return min;
        }

        public double GetMaxGrade()
        {
            if(this.grades.Count == 0) return 0.0;
            
            var max = double.MinValue;
            this.grades.ForEach(grade =>
            {
                max = Math.Max(max, grade);
            });

            return max;
        }
        public Statistics GetStatistics() {
            double avg = this.GetAverageGrade();
            double high = this.GetMaxGrade();
            double min = this.GetMinGrade();
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

        private List<Double> grades;
        // List<Grade> courseGrade;
        // private string name;

        readonly string category = "Science";

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