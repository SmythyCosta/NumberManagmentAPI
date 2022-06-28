using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using NumberManagmentAPI.DTO;

namespace NumberManagmentAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDBContext _db;

        public CategoryRepository(ApplicationDBContext db)
        {
            this._db = db;
        }

        public List<CategoryModel> getAll()
        {

            var ct = _db.Category.ToList();
            return ct;
        }

        public CategoryModel getOne(int id)
        {
            return _db.Category.AsNoTracking().FirstOrDefault(
                item => item.CategoryId == id);
        }

        public void Save(CategoryModel obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
        }

        public CategoryModel Update(CategoryModel obj)
        {
            _db.Category.Update(obj);
            _db.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var obj = getOne(id);

            if (obj != null)
            {
                _db.Entry(obj).State = EntityState.Deleted;
                _db.SaveChanges();
            }
        }
    }
}
