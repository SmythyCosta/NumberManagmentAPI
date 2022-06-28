using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using NumberManagmentAPI.DTO;

namespace NumberManagmentAPI.Repository
{
    public interface ICategoryRepository
    {

        public List<CategoryModel> getAll();

        public CategoryModel getOne(int id);

        public void Save(CategoryModel obj);

        public CategoryModel Update(CategoryModel obj);

        public void Delete(int id);

    }
}
