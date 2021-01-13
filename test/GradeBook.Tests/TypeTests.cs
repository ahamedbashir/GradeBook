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
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        private string IncrementCount(string mesasge)
        {
            count++;
            return mesasge.ToLower();
        }

        private string ReturnMessage(string mesasge)
        {
            count++;
            return mesasge;
        }

        [Fact]
        public void ValueTypesPassByRef()
        {
            var x = GetInt();
            SetInt(ref x);
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
        public void StringsBehaveLikeValeuTypes()
        {
            string name = "Max";
            MakeUpper(name);

            Assert.Equal("Max", name);
        }

        private void MakeUpper(string name)
        {
            name.ToUpper();
        }

        [Fact]
        public void CsharpIsPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetNameRef(out InMemoryBook book, string newName)
        {
            book = new InMemoryBook(newName);
        }

        [Fact]
        public void CsharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(InMemoryBook book, string newName)
        {
            book = new InMemoryBook(newName);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void SetName(InMemoryBook book1, string newName)
        {
            book1.Name = newName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);

            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoBooksCanReferenceSameObject() {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

    }
}
