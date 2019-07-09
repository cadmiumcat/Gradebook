using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(2.1);
            book.AddGrade(2.3);

            //act 
            var result = book.GetStatistics();

            //assert
            Assert.Equal(2, result.Average, 0);
            Assert.Equal(2, result.High, 0);
            Assert.Equal(2, result.Low, 0);
        }
    }
}
