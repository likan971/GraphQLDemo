using GraphQL.Types;

namespace GraphQLDemo.Services
{
    public interface IService
    {
        QueryArguments GetArguments();

        object GetResolvers(ResolveFieldContext<object> context);
    }
}
