using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void CsharpCanPassByRef() 
        {
            //arrange
            var book1 = GetBook("Book 1");

            //act 
            GetBookSetName(ref book1, "New Name");
            
            //assert
            Assert.Equal("New Name", book1.Name);

        }
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }     

        [Fact]
        public void CanSetNameFromReference() 
        {
            //arrange
            var book1 = GetBook("Book 1");

            //act 
            SetName(book1, "New Name");
            //assert
            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(Book book1, string name)
        {
            book1.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects() 
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act 

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject() 
        {
            //arrange
            var book1 = GetBook("Book 1");

            //act 
            var book2 = book1;

            //assert
            Assert.Same(book1, book2);
            //the following line tests the same (it's what goes on behind the scenes)
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
