using System;
using NumberManagmentAPI.DTO;
using NumberManagmentAPI.Repository;
using NumberManagmentAPI.Enum;
using App.Models;
using System.Threading.Tasks;

namespace NumberManagmentAPI.Service
{
    public class NumberOperationService : INumberOperationService
    {
         private readonly INumberRepository _repository;

         public NumberOperationService(INumberRepository repository)
        {
            _repository = repository;
        }

        public void ActiveNumber(ActiveNumberInDTO input)
        {
            try
            {
                // validate number request
                ValidateRequestNumber(input);

                // find number
                var number = FindNumber(input);

                // check status number
                ChackStatusNumber(number);

                number.StatusId = (int)NumberStatus.IN_USE;
                number.DhUpdated = DateTime.Today;

                _repository.Active(number);
            }
            catch
            {
                throw new Exception("Fail in Operation!");
            }
        }

        private NumberModel FindNumber(ActiveNumberInDTO input){
            return _repository.GetNumberByCountryDddPrefixSufix(
                                    input.Country,
                                    input.Ddd,
                                    input.Prefix,
                                    input.Sufix);
        }

        private void ValidateRequestNumber(ActiveNumberInDTO input)
        {
            if (NullOrEmpty(input.Country) ||
                    NullOrEmpty(input.Ddd) ||
                    NullOrEmpty(input.Prefix) ||
                    NullOrEmpty(input.Sufix))
            {
                throw new Exception("Invalid number!");
            }
            
        }

        private void ChackStatusNumber(App.Models.NumberModel number)
        {
            if (number.StatusId != (int) NumberStatus.AVAILABLE)
            {
                throw new Exception("Invalid Status of number!");
            }
        }

        private bool NullOrEmpty(string value)
        {
            return String.IsNullOrEmpty(value);
        }

        public void CancelNumber(ActiveNumberInDTO input)
        {
            // find number
            var number = FindNumber(input);

            ValidateStatusCancel(number);

            number.StatusId = (int)NumberStatus.IN_QUARANTINE;
            number.DhUpdated = DateTime.Today;

            _repository.Active(number);
        }

        private void ValidateStatusCancel(App.Models.NumberModel number)
        {
            if (number.StatusId != (int) NumberStatus.IN_USE)
            {
                throw new Exception("Only numbers in use can be canceled!");
            }
        }

        public async Task<NumberModel[]> GetAllNubersByStatus(int status)
        {
            var listNumbers = await _repository.GetAllNubersBystatus(status);  
            return listNumbers; 
        }
    }
}