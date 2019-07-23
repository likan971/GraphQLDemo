using GraphQL.Types;

namespace GraphQLDemo.Common
{
    public class GraphQLHelper
    {
        public static QueryArgument<T> NewArgument<T>(string name, string description, object defaultValue = null) where T : IGraphType
        {
            var argument = new QueryArgument<T>
            {
                Name = name,
                Description = description
            };

            if (defaultValue != null)
            {
                argument.DefaultValue = defaultValue;
            }

            return argument;
        }
    }
}
