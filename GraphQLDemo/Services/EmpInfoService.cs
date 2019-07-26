using GraphQL.Types;
using GraphQLDemo.Repositories;
using System;
using System.Linq;

namespace GraphQLDemo.Services
{
    public interface IEmpInfoService : IService
    {

    }

    public class EmpInfoService : IEmpInfoService
    {
        private readonly IEmpInfoRepository _empInfoRepository;

        public EmpInfoService(IEmpInfoRepository empInfoRepository)
        {
            _empInfoRepository = empInfoRepository;
        }

        public QueryArguments GetArguments()
        {
            throw new NotImplementedException();
        }

        public object GetResolvers(ResolveFieldContext<object> context)
        {
            return _empInfoRepository.GetQuery()
                                     .Where(emp => emp.Date == DateTime.Today &&
                                            emp.Event == "1-入职")
                                     .ToList();
        }
    }
}
