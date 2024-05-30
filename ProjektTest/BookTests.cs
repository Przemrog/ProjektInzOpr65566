using ProjektSklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTest
{
    public class BookTests
    {
        [Fact]
        public void CanChangeBookTitle()
        {
            var book = new Book { Title = "Zemsta" };
            book.Title = "Dziady";
            Assert.Equal("Dziady", book.Title);
        }

        [Fact]
        public void CanSetAuthor()
        {
            var book = new Book();
            var author = new Author { Name = "Aleksander Fredro" };
            book.Author = author;
            Assert.Equal("Aleksander Fredro", book.Author.Name);
        }

        [Fact]
        public void CanSetCategory()
        {
            var book = new Book();
            var category = new Category { Name = "Fantasy" };
            book.Category = category;
            Assert.Equal("Fantasy", book.Category.Name);
        }
    }
}
