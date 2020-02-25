using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logging.Models;

namespace Logging.Services
{
    public class BrokerService : Service, IService<Broker>
    {
        private readonly IList<Broker> brokers = new List<Broker>();

        public BrokerService()
        {
            Populate(brokers, "Broker");
        }
        private Broker GetBrokerFromCode(string code)
        {
            var broker = brokers.SingleOrDefault(i => Equals(i.Code, code));
            if(broker == null)
            {
                throw new ArgumentException($"Broker code: {code} is invalid");
            }
            return broker;
        }

        public Task<Broker> GetItemAsync(string code) => Task.FromResult(GetBrokerFromCode(code));

        public Task<IEnumerable<Broker>> GetItemsAsync() => Task.FromResult(brokers.AsEnumerable());
    }
}
