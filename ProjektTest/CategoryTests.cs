using ProjektSklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTest
{
    public class CategoryTests
    {
        [Fact]
        public void CanChangeCategoryName()
        {
            var category = new Category { Name = "Poezja" };
            category.Name = "Dramat";
            Assert.Equal("Dramat", category.Name);
        }

        [Fact]
        public void DefaultCategoryIdShouldBeZero()
        {
            var category = new Category();
            Assert.Equal(0, category.CategoryId);
        }

        [Fact]
        public void CanSetCategoryId()
        {
            var category = new Category();
            category.CategoryId = 1;
            Assert.Equal(1, category.CategoryId);
        }
    }
}
