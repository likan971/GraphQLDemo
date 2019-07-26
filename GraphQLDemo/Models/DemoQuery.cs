using GraphQL.Types;
using GraphQLDemo.Models.GraphQLTypes;
using GraphQLDemo.Services;

namespace GraphQLDemo.Models
{
    public class DemoQuery : ObjectGraphType
    {
        public DemoQuery(IEmpInfoService empInfoService,
                         ITeacherService teacherService,
                         ILessonPlanService lessonPlanService)
        {
            Field<ListGraphType<EmpInfoType>>("newEmployees", "当日新入职员工", null, context => empInfoService.GetResolvers(context));
            Field<TeacherType>("teacher", "根据HrCode查询老师信息", teacherService.GetArguments(), context => teacherService.GetResolvers(context));
            Field<ListGraphType<LessonPlanType>>("lessonPlan", "查询教案", lessonPlanService.GetArguments(), context => lessonPlanService.GetResolvers(context));
        }
    }
}
