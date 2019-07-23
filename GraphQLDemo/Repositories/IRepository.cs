using System.Linq;

namespace GraphQLDemo.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetQuery();

        IQueryable<T> GetIncludableQuery();
    }
}
