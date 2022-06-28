using Microsoft.EntityFrameworkCore;
using NumberManagmentAPI;
using NumberManagmentAPI.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace App.Tests.Persist
{
    public class T1
    {
        //private DbContextOptions<ApplicationDBContext> dbContextOptions;

        //private readonly ApplicationDBContext _db;
        private readonly ICategoryRepository _repository;

        public T1(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [Fact]
        public void CategoryRepository_GetAll_Test()
        {

            //ApplicationDBContext context = new ApplicationDBContext(dbContextOptions);
            //ICategoryRepository repository = new CategoryRepository(context);

            var all = _repository.getAll();

            Assert.NotNull(all);
        }

    }
}
