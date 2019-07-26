using GraphQLDemo.Models;
using GraphQLDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GraphQLDemo.Repositories
{
    public interface IEmpInfoRepository : IRepository<BP_EmpInfo>
    {

    }

    public class EmpInfoRepository : IEmpInfoRepository
    {
        private readonly BpfDbContext _dbContext;

        public EmpInfoRepository(BpfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<BP_EmpInfo> GetIncludableQuery()
        {
            throw new NotImplementedException();
        }

        public IQueryable<BP_EmpInfo> GetQuery()
        {
            return _dbContext.BP_EmpInfo.AsNoTracking();
        }
    }
}
