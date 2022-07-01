using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace NumberManagmentAPI.Repository
{
    public interface INumberRepository
    {
        Task<NumberModel[]> GetNumbers();
        NumberModel GetNumberByCountryDddPrefixSufix(String country, String ddd, String prefix, String sufix);
        void Active(NumberModel n);
        Task<NumberModel[]> GetAllNubersBystatus(int status);
    }
}