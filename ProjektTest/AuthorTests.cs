using ProjektSklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTest
{
    public class AuthorTests
    {
        [Fact]
        public void CanChangeAuthorName()
        {
            var author = new Author { Name = "Adam Mickiewicz" };
            author.Name = "Juliusz Słowacki";
            Assert.Equal("Juliusz Słowacki", author.Name);
        }

        [Fact]
        public void DefaultAuthorIdShouldBeZero()
        {
            var author = new Author();
            Assert.Equal(0, author.AuthorId);
        }

        [Fact]
        public void CanSetAuthorId()
        {
            var author = new Author();
            author.AuthorId = 1;
            Assert.Equal(1, author.AuthorId);
        }
    }
}
