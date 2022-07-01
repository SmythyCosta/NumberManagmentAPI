using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.EntityFrameworkCore;


namespace NumberManagmentAPI.Repository
{
    public class NumberRepository : INumberRepository
    {

        private readonly ApplicationDBContext _db;

        public NumberRepository(ApplicationDBContext db)
        {
            this._db = db;
        }

        public async Task<NumberModel[]> GetNumbers()
        {

            IQueryable<NumberModel> query = _db.Number;

            return await query.ToArrayAsync();
        }

        public void Active(NumberModel n)
        {
            _db.Number.Update(n);
            _db.SaveChanges();
        }

        public NumberModel GetNumberByCountryDddPrefixSufix(string country, string ddd, string prefix, string sufix)
        {
            var number = _db.Number.AsNoTracking().FirstOrDefault(n => 
                            n.Country == country &&
                            n.Ddd == ddd &&
                            n.Prefix == prefix &&
                            n.Sufix == sufix);
            
            return number;
        }

        public async Task<NumberModel[]> GetAllNubersBystatus(int status)
        {
            IQueryable<NumberModel> query = _db.Number
                .Include(n => n.Category)
                .Include(n => n.NumberStatus);

            query = query
                       .AsNoTracking()
                       .Where(n => n.StatusId == status)
                       .OrderBy(n => n.Id);

            return await query.ToArrayAsync();
        }
    }
}