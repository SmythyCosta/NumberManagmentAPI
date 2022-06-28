using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using NumberManagmentAPI.DTO;
using NumberManagmentAPI.Repository;

namespace NumberManagmentAPI.Service
{
    public class CategoryService : ICategoryService
    {
        private const bool Active = true;
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<CategoryDTO> GetAll()
        {
            List<CategoryDTO> dtoResponse = new List<CategoryDTO>();
            var CategoriesDB = _repository.getAll();

            if (CategoriesDB != null)
            {
                foreach (CategoryModel cat in CategoriesDB)
                {

                    var dto = ParseCategoryToCategoryDTO(cat);

                    dtoResponse.Add(dto);
                }

            }

            return dtoResponse;
        }

        public CategoryDTO GetById(int id) 
        {
            var item = _repository.getOne(id);
            return ParseCategoryToCategoryDTO(item);
        }

        public void Save(CategoryDTO obj)
        {
            _repository.Save(ParseCategoryDTOToCategory(obj));
        }

        public CategoryDTO Update(CategoryDTO obj)
        {
            if (obj == null)
                throw new NotImplementedException();

            var objDB = _repository.getOne(obj.CategoryId);
            if (objDB == null)
                 return null;

            var cat = _repository.Update(ParseCategoryDTOToCategory(obj));

            return ParseCategoryToCategoryDTO(cat);
        }

        public void Delete(int id)
        {
            var obj = _repository.getOne(id);

            if (obj == null)
                return;

            _repository.Delete(id);
        }

        private CategoryDTO ParseCategoryToCategoryDTO(CategoryModel cat)
        {
            if (cat == null)
                return null;

            var Out = new CategoryDTO(cat.CategoryId,
                                              cat.CategoryName,
                                              cat.CategoryDescription,
                                              Active);

            return Out;
        }

        private CategoryModel ParseCategoryDTOToCategory(CategoryDTO obj)
        {

            var Category = new CategoryModel()
            {
                CategoryId = obj.CategoryId,
                CategoryName = obj.CategoryName,
                CategoryDescription = obj.CategoryDescription
            };

            return Category;
        }
        
    }
}