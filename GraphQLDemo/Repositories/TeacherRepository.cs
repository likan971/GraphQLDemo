using GraphQLDemo.Models;
using GraphQLDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GraphQLDemo.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        string GetUserIdByHrCode(string hrCode);
    }

    public class TeacherRepository : ITeacherRepository
    {
        private readonly PcpDbContext _dbContext;

        public TeacherRepository(PcpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Teacher> GetQuery()
        {
            return _dbContext.Teachers.AsNoTracking();
        }

        public IQueryable<Teacher> GetIncludableQuery()
        {
            throw new NotSupportedException();
        }

        public string GetUserIdByHrCode(string hrCode)
        {
            return GetQuery().Where(t => t.HrCode == hrCode)
                             .Select(t => t.UserId)
                             .FirstOrDefault();
        }
    }
}
