using GraphQL.Types;
using GraphQLDemo.Common;
using GraphQLDemo.Models.Entities;
using GraphQLDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDemo.Services
{
    public interface ILessonPlanService : IService
    {
        object GetResolvers(ResolveFieldContext<Teacher> context);
    }

    public class LessonPlanService : ILessonPlanService
    {
        private readonly ILessonPlanRepository _lessonPlanRepository;

        private readonly string LessonId = "lessonId";
        private readonly string StartDate = "startDate";
        private readonly string EndDate = "endDate";

        private List<LessonPlan> Default => new List<LessonPlan>();

        public LessonPlanService(ILessonPlanRepository lessonPlanRepository)
        {
            _lessonPlanRepository = lessonPlanRepository;
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

        public object GetResolvers(ResolveFieldContext<object> context)
        {
            var query = _lessonPlanRepository.GetIncludableQuery();
            var lessonId = context.GetArgument<string>(LessonId);
            var startDate = context.GetArgument<DateTime?>(StartDate);
            var endDate = context.GetArgument<DateTime?>(EndDate);

            return Resolve(query, lessonId, startDate, endDate);
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

            return Resolve(query, lessonId, startDate, endDate);
        }

        private object Resolve(IQueryable<LessonPlan> query, string lessonId, DateTime? startDate, DateTime? endDate)
        {
            if (query == null)
            {
                return Default;
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
                    return Default;
                }
            }

            return query.ToList() ?? Default;
        }
    }
}
