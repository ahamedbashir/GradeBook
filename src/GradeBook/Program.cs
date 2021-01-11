using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Max's grade book");
            book.addGrade(12.7);
            book.addGrade(10.3);
            book.addGrade(6.11);
            book.addGrade(4.1);
            
            book.showStatistic();
        }
    }
}
