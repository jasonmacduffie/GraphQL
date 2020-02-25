using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logging.Models;

namespace Logging.Services
{
    public class BusinessFunctionService : Service, IService<BusinessFunction>
    {
        private readonly IList<BusinessFunction> businessFunctions = new List<BusinessFunction>();

        public BusinessFunctionService()
        {
            Populate(businessFunctions, "BusinessFunction");
        }

        private BusinessFunction GetBusinessFunctionFromCode(string code)
        {
            var businessFunction = businessFunctions.SingleOrDefault(i => Equals(i.Code, code));
            if (businessFunction == null)
            {
                throw new ArgumentException($"Business Function code: {code} is invalid");
            }
            return businessFunction;
        }

        public Task<IEnumerable<BusinessFunction>> GetBusinessFunctionsAsync() => Task.FromResult(businessFunctions.AsEnumerable());

        public Task<BusinessFunction> GetBusinessFunctionFromCodeAsync(string code) => Task.FromResult(GetBusinessFunctionFromCode(code));

        public Task<BusinessFunction> GetItemAsync(string code) => Task.FromResult(GetBusinessFunctionFromCode(code));

        public Task<IEnumerable<BusinessFunction>> GetItemsAsync() => Task.FromResult(businessFunctions.AsEnumerable());
    }
}
