using GraphQL;

namespace Logging.Schema
{
    public class MessageSchema : GraphQL.Types.Schema
    {
        public MessageSchema(Query query, IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
        }
    }
}