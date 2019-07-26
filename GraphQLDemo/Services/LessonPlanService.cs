using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Common;
using GraphQLDemo.Models.Entities;
using GraphQLDemo.Models.GraphQLTypes;
using GraphQLDemo.Models.Requests;
using GraphQLDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDemo.Services
{
    public interface ILessonPlanService : IService
    {
        QueryArguments GetInputArguments();

        object GetResolvers(ResolveFieldContext<Teacher> context);

        object GetMutationResolvers(ResolveFieldContext<object> context);
    }

    public class LessonPlanService : ILessonPlanService
    {
        private readonly ILessonPlanRepository _lessonPlanRepository;
        private readonly ITeacherRepository _teacherRepository;

        private readonly string LessonId = "lessonId";
        private readonly string StartDate = "startDate";
        private readonly string EndDate = "endDate";

        private List<LessonPlan> Default => new List<LessonPlan>();

        public LessonPlanService(ILessonPlanRepository lessonPlanRepository,
                                 ITeacherRepository teacherRepository)
        {
            _lessonPlanRepository = lessonPlanRepository;
            _teacherRepository = teacherRepository;
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments(new List<QueryArgument>
            {
                GraphQLHelper.NewArgument<StringGraphType>(LessonId, "课程Id"),
                GraphQLHelper.NewArgument<DateGraphType>(StartDate, "起始日期"),
                GraphQLHelper.NewArgument<DateGraphType>(EndDate, "结束日期")
            });
        }

        public QueryArguments GetInputArguments()
        {
            return new QueryArguments(new List<QueryArgument>
            {
                GraphQLHelper.NewArgument<NonNullGraphType<StringGraphType>>("hrCode", "HrCode"),
                GraphQLHelper.NewArgument<NonNullGraphType<LessonPlanInputType>>("lessonPlanInput", "教案输入参数")
            });
        }

        public object GetResolvers(ResolveFieldContext<object> context)
        {
            var query = _lessonPlanRepository.GetIncludableQuery();
            var lessonId = context.GetArgument<string>(LessonId);
            var startDate = context.GetArgument<DateTime?>(StartDate);
            var endDate = context.GetArgument<DateTime?>(EndDate);

            var (result, message) = Resolve(query, lessonId, startDate, endDate);
            if (!string.IsNullOrEmpty(message))
            {
                context.Errors.Add(new ExecutionError(message));
            }

            return result;
        }

        public object GetResolvers(ResolveFieldContext<Teacher> context)
        {
            var hrCode = context.Source.HrCode;
            if (string.IsNullOrEmpty(hrCode))
            {
                return null;
            }

            var query = _lessonPlanRepository.GetQuery().Where(lp => lp.Teacher.HrCode == hrCode);
            var lessonId = context.GetArgument<string>(LessonId);
            var startDate = context.GetArgument<DateTime?>(StartDate);
            var endDate = context.GetArgument<DateTime?>(EndDate);

            var (result, message) = Resolve(query, lessonId, startDate, endDate);
            if (!string.IsNullOrEmpty(message))
            {
                context.Errors.Add(new ExecutionError(message));
            }

            return result;
        }

        public object GetMutationResolvers(ResolveFieldContext<object> context)
        {
            var operationName = context.Operation.Name;
            if (operationName == "CreateLessonPlan")
            {
                var hrCode = context.GetArgument<string>("hrCode");
                var userId = _teacherRepository.GetUserIdByHrCode(hrCode);
                if (!string.IsNullOrEmpty(userId))
                {
                    var lessonPlan = context.GetArgument<LessonPlanRequest>("lessonPlanInput");
                    return _lessonPlanRepository.NewLessonPlan(userId, lessonPlan);
                }

                context.Errors.Add(new ExecutionError("hrCode not exist"));
                return default;
            }

            return default;
        }

        private (object, string) Resolve(IQueryable<LessonPlan> query, string lessonId, DateTime? startDate, DateTime? endDate)
        {
            var errorMessage = string.Empty;

            if (query == null)
            {
                errorMessage = "query is null";
                return (Default, errorMessage);
            }
            if (!string.IsNullOrEmpty(lessonId))
            {
                query = query.Where(lp => lp.LessonId == lessonId);
            }
            else
            {
                if (startDate != null)
                {
                    query = query.Where(lp => lp.LessonDate >= startDate);
                }
                if (endDate != null)
                {
                    query = query.Where(lp => lp.LessonDate <= endDate);
                }

                if (startDate == null && endDate == null)
                {
                    errorMessage = "at least one parameter is reuqired for lessonPlans";
                    return (Default, errorMessage);
                }
            }

            return (query.ToList() ?? Default, errorMessage);
        }
    }
}
