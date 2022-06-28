using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using NumberManagmentAPI.DTO;
using NumberManagmentAPI.Repository;

namespace NumberManagmentAPI.Service
{
    public interface ICategoryService
    {
        public List<CategoryDTO> GetAll();
        
        CategoryDTO GetById(int id);
        
        void Save(CategoryDTO obj);
        
        CategoryDTO Update(CategoryDTO obj);

        void Delete(int id);
    }
}
