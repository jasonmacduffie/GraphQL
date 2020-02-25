using GraphQL.Types;
using Logging.Models;
using Logging.Services;

namespace Logging.Schema
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType(IService<Broker> brokers, IService<BusinessFunction> businessFunctions)
        {
            Field(o => o.EmailEntryId);
            Field(o => o.BusinessFunctionCode);
            Field(o => o.BrokerCode);
            Field(o => o.Created);
            Field(o => o.Modified);
            Field<BrokerType>("broker", resolve: context => brokers.GetItemAsync(context.Source.BrokerCode));
            Field<BusinessFunctionType>("businessFunction", resolve: context => businessFunctions.GetItemAsync(context.Source.BusinessFunctionCode));
        }
    }
}
