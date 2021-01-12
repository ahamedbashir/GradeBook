using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var book = new Book("");
            book.addGrade(89.1);
            book.addGrade(90.5);
            book.addGrade(77.3);

            // act
            var result = book.getStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.Highest, 1);
            Assert.Equal(77.3, result.Lowest, 1);
            
        }
    }
}
