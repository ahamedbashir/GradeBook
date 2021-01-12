using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void csharpIsPassByRef()
        {
            var book1 = getBook("Book 1");
            getBookSetNameRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void getBookSetNameRef(ref Book book, string newName)
        {
            book = new Book(newName);
        }

        [Fact]
        public void csharpIsPassByValue()
        {
            var book1 = getBook("Book 1");
            getBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }
        private void getBookSetName(Book book, string newName)
        {
            book = new Book(newName);
        }

        [Fact]
        public void canSetNameFromReference()
        {
            var book1 = getBook("Book 1");
            setName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void setName(Book book1, string newName)
        {
            book1.Name = newName;
        }

        [Fact]
        public void getBookReturnsDifferentObjects()
        {
            var book1 = getBook("Book 1");
            var book2 = getBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);

            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void twoBooksCanReferenceSameObject() {
            var book1 = getBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book getBook(string name)
        {
            return new Book(name);
        }

    }
}
