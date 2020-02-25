using GraphQL.Types;
using Logging.Models;

namespace Logging.Schema
{
    public class BrokerType : ObjectGraphType<Broker>
    {
        public BrokerType()
        {
            Field(i => i.Code);
            Field(i => i.Name);
            Field(i => i.Description);
        }
    }
}
