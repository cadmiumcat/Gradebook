using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
        //Given
            WriteLogDelegate log = ReturnMessage; // initialise WriteLogDelegate
            log += ReturnMessage; // WriteLogDelegate points to ReturnMessage
            log += IncrementCount;
        //When
            var result = log("Hello!");
        //Then
            Assert.Equal(3, count);
            
        }

        string IncrementCount(string message) //input and output types match delegate
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message) //input and output types match delegate
        {
            count++;
            return message;
        }



        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
        //Given
            var x = GetInt();
        //When
            SetInt(ref x);
        //Then
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

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
        public void StringsBehaveLikeValueTypes()
        {
        //Given
            string name = "Cat";
        
        //When
            var upper = MakeUppercase(name);
        
        //Then
            Assert.Equal("Cat", name);
            Assert.Equal("CAT", upper);

        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
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
