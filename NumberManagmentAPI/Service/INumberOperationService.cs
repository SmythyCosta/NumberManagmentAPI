using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NumberManagmentAPI.DTO;

namespace NumberManagmentAPI.Service
{
    public interface INumberOperationService
    {
        void ActiveNumber(ActiveNumberInDTO input);
    }
}