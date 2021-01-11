using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();

            var grades = new List<double>(){12.7, 10.3, 6.11, 4.1};
            var result = 0.0;
            var max = double.MinValue;
            var min = double.MaxValue;

            foreach(var grade in grades) {
                result += grade;
                max = Math.Max(max, grade);
                min = Math.Min(min, grade);
            }

            result /= grades.Count;

            Console.WriteLine($"The average grade is : {result:n2}");
            Console.WriteLine($"The max grade is : {max:n2}");
            Console.WriteLine($"The min grade is : {min:n2}");
        }
    }
}
