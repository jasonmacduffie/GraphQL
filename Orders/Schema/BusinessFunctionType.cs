using GraphQL.Types;
using Logging.Models;

namespace Logging.Schema
{
    public class BusinessFunctionType : ObjectGraphType<BusinessFunction>
    {
        public BusinessFunctionType()
        {
            Field(i => i.Code);
            Field(i => i.Name);
            Field(i => i.Description);
        }
    }
}
