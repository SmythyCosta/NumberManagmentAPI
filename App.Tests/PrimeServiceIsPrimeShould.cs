using System;
using NumberManagmentAPI.Service;
using Xunit;

namespace App.Tests
{
    public class CategoryRepositoryIntegrationDBTest
    {

        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var primeService = new PrimeService();
            bool result = primeService.IsPrime(1);

            //Assert.False(result, "1 should not be prime");
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_InputIs1_ReturnEception()
        {
            var primeService = new PrimeService();
            var outPut = true;

            try
            {
                bool result = primeService.IsPrime(50);
            }
            catch (Exception e)
            {
                outPut = false;
                Console.WriteLine("{0} Exception caught.", e);
            }

            Assert.False(outPut);
        }
    }
}
