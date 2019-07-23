using GraphQL.Types;
using GraphQLDemo.Models.GraphQLTypes;
using GraphQLDemo.Services;

namespace GraphQLDemo.Models
{
    public class DemoQuery : ObjectGraphType
    {
        private readonly ITeacherService _teacherService;
        private readonly ILessonPlanService _lessonPlanService;

        public DemoQuery(ITeacherService teacherService, ILessonPlanService lessonPlanService)
        {
            _teacherService = teacherService;
            _lessonPlanService = lessonPlanService;

            Field<TeacherType>("teacher", "根据HrCode查询老师信息", _teacherService.GetArguments(), context => _teacherService.GetResolvers(context));
            Field<LessonPlanType>("lessonPlan", "查询教案", _lessonPlanService.GetArguments(), context => _lessonPlanService.GetResolvers(context));
        }
    }
}
