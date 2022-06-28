using App.Models;
using Moq;
using System;
using System.Collections.Generic;
using NumberManagmentAPI.Repository;
using NumberManagmentAPI.Service;
using Xunit;

namespace App.Tests.Service
{
    public class CategoryServiceTest
    {

        private CategoryService _categoryService;

        public CategoryServiceTest()
        {
            _categoryService = new CategoryService(new Mock<ICategoryRepository>().Object);
        }

        [Fact]
        public void getAll_ReturnNotNull()
        {

            List<CategoryModel> lc = new List<CategoryModel>();

            var c1 = new CategoryModel()
                {
                    CategoryId = 1000,
                    CategoryName = "B2B",
                    CategoryDescription = "DESC B2B"

            };
            var c2 = new CategoryModel()
            {
                CategoryId = 2000,
                CategoryName = "B2C",
                CategoryDescription = "DESC B2C"

            };
            var c3 = new CategoryModel()
            {
                CategoryId = 3000,
                CategoryName = "B5K",
                CategoryDescription = "DESC B5K"

            };

            lc.Add(c1);
            lc.Add(c2);
            lc.Add(c3);

            var rep = new Mock<ICategoryRepository>();
            rep.Setup(x => x.getAll()).Returns(lc);

            _categoryService = new CategoryService(rep.Object);
            var result = _categoryService.GetAll();

            Assert.True(result.Count > 0);
        }


    }
}
