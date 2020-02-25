using GraphQL.Types;
using Logging.Services;
using Logging.Models;

namespace Logging.Schema
{
    public class Query : ObjectGraphType<object>
    {
        public Query(IService<Broker> brokers, IService<BusinessFunction> businessFunctions, IService<Message> messages)
        {
            Name = "Query";

            Field<ListGraphType<BrokerType>>(
                "brokers",
                resolve: context => brokers.GetItemsAsync()
            );

            Field<ListGraphType<MessageType>>(
                "messages",
                resolve: context => messages.GetItemsAsync()
            );

            Field<ListGraphType<BusinessFunctionType>>(
                "businessFunctions",
                resolve: context => businessFunctions.GetItemsAsync()
            );

            FieldAsync<MessageType>(
                "messageById",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
                resolve: async context => await context.TryAsyncResolve(
                        async c => await messages.GetItemAsync(c.GetArgument<string>("id"))
                    )
            );

            FieldAsync<MessageType>(
                "brokerFromCode",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code" }),
                resolve: async context => await context.TryAsyncResolve(
                        async c => await brokers.GetItemAsync(c.GetArgument<string>("code"))
                    )
            );

            FieldAsync<MessageType>(
                "businessFunctionFromCode",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code" }),
                resolve: async context => await context.TryAsyncResolve(
                        async c => await businessFunctions.GetItemAsync(c.GetArgument<string>("code"))
                    )
            );
        }
    }
}
