using GraphQL;
using GraphQL.Types;

namespace GraphQLDemo.Models
{
    public class DemoSchema : Schema
    {
        public DemoSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<DemoQuery>();
        }
    }
}
