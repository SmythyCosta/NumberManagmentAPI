using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using NumberManagmentAPI.DTO;

namespace NumberManagmentAPI.Service
{
    public interface INumberOperationService
    {
        void ActiveNumber(ActiveNumberInDTO input);
        void CancelNumber(ActiveNumberInDTO input);
        Task<NumberModel[]> GetAllNubersByStatus(int status);
    }
}