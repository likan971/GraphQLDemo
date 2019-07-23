using GraphQL.Types;
using GraphQLDemo.Models.Entities;
using GraphQLDemo.Services;

namespace GraphQLDemo.Models.GraphQLTypes
{
    public class TeacherType : ObjectGraphType<Teacher>
    {
        private readonly ILessonPlanService _lessonPlanService;

        public TeacherType(ILessonPlanService lessonPlanService)
        {
            _lessonPlanService = lessonPlanService;

            Name = "Teacher";
            Description = "老师（用户）";
            Field(t => t.UserId).Description("用户Id");
            Field(t => t.DisplayName, nullable: true).Description("老师姓名");
            Field(t => t.Grade, nullable: true).Description("年级");
            Field(t => t.WorkLocation).Description("工作地点");
            Field<ListGraphType<LessonPlanType>>(nameof(Teacher.LessonPlans), "老师名下的教案", _lessonPlanService.GetArguments(), context => _lessonPlanService.GetResolvers(context));
        }
    }
}
