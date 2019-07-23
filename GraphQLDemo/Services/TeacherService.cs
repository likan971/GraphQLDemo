using GraphQL.Types;
using GraphQLDemo.Common;
using GraphQLDemo.Models.Entities;
using GraphQLDemo.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDemo.Services
{
    public interface ITeacherService : IService
    {

    }

    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        private readonly string HrCode = "hrCode";

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments(new List<QueryArgument>
            {
                GraphQLHelper.NewArgument<StringGraphType>(HrCode, "HrCode")
            });
        }

        public object GetResolvers(ResolveFieldContext<object> context)
        {
            var query = _teacherRepository.GetQuery();

            var hrCode = context.GetArgument<string>(HrCode);
            if (!string.IsNullOrEmpty(hrCode))
            {
                return query.FirstOrDefault(t => t.HrCode == hrCode);
            }

            return null;
        }
    }
}
