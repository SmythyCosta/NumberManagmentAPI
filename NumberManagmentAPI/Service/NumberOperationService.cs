using System;
using NumberManagmentAPI.DTO;
using NumberManagmentAPI.Repository;
using NumberManagmentAPI.Enum;

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

                // checked availability
                var number = _repository.GetNumberByCountryDddPrefixSufix(
                                    input.Country,
                                    input.Ddd,
                                    input.Prefix,
                                    input.Sufix);

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
    }
}