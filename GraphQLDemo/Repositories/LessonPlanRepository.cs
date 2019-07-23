using GraphQLDemo.Models;
using GraphQLDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GraphQLDemo.Repositories
{
    public interface ILessonPlanRepository: IRepository<LessonPlan>
    {

    }

    public class LessonPlanRepository : ILessonPlanRepository
    {
        private readonly PcpDbContext _dbContext;

        public LessonPlanRepository(PcpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<LessonPlan> GetQuery()
        {
            return _dbContext.LessonPlan.AsNoTracking();
        }

        public IQueryable<LessonPlan> GetIncludableQuery()
        {
            return _dbContext.LessonPlan.Include(lp => lp.Teacher).AsNoTracking();
        }
    }
}
