using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Max's grade book");
            book.GradeAdded += OnGradeAdded;


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
                    book.AddGrade(grade);
                } catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                } catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
                
            }
            
            
            var stats = book.GetStatistics();

            Console.WriteLine($"The average grade is : {stats.Average:n2}");
            Console.WriteLine($"The max grade is : {stats.Highest:n2}");
            Console.WriteLine($"The min grade is : {stats.Lowest:n2}");
            Console.WriteLine($"The Letter grade is : {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade Added");
        }
    }
}
