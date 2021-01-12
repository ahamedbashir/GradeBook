using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Max's grade book");

            while(true)
            {
                Console.Write("Enter a grade or 'q' to quit : ");
                var input = Console.ReadLine();
                if(input.ToLower() == "q") {
                    break;
                }
                try
                {
                    var grade = double.Parse(input); 
                    book.addGrade(grade);
                } catch(Exception ex) {
                    Console.WriteLine(ex);
                }
                
            }
            
            
            var stats = book.getStatistics();

            Console.WriteLine($"The average grade is : {stats.Average:n2}");
            Console.WriteLine($"The max grade is : {stats.Highest:n2}");
            Console.WriteLine($"The min grade is : {stats.Lowest:n2}");
            Console.WriteLine($"The Letter grade is : {stats.Letter}");
        }
    }
}
