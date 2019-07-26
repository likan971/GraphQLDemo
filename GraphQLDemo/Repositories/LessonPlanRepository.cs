using GraphQLDemo.Models;
using GraphQLDemo.Models.Entities;
using GraphQLDemo.Models.Requests;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GraphQLDemo.Repositories
{
    public interface ILessonPlanRepository: IRepository<LessonPlan>
    {
        LessonPlan NewLessonPlan(string userId, LessonPlanRequest lessonPlan);
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

        public LessonPlan NewLessonPlan(string userId, LessonPlanRequest lessonPlan)
        {
            var result = _dbContext.LessonPlan.Add(new LessonPlan
            {
                UserId = userId,
                LessonId = lessonPlan.LessonId,
                ToType = lessonPlan.ToType,
                Title = lessonPlan.Title,
                LessonDate = lessonPlan.LessonDate,
                Subject = lessonPlan.Subject,
                Grade = lessonPlan.Grade
            });

            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
