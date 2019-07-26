using GraphQL.Types;
using GraphQLDemo.Models.Entities;

namespace GraphQLDemo.Models.GraphQLTypes
{
    public class LessonPlanType : ObjectGraphType<LessonPlan>
    {
        public LessonPlanType()
        {
            Name = "LessonPlan";
            Description = "教案";
            Field(t => t.TeachingPlanId).Description("教案Id");
            Field(t => t.LessonId).Description("课程Id");
            Field(t => t.ToType, nullable: true).Description("教案类型");
            Field(t => t.Title, nullable: true).Description("教案标题");
            Field(t => t.LessonDate, nullable: true).Description("课程日期");
            Field(t => t.Subject, nullable: true).Description("学科");
            Field(t => t.Grade, nullable: true).Description("年级");
            Field<TeacherType>(nameof(LessonPlan.Teacher), "所属老师");
        }
    }

    public class LessonPlanInputType : InputObjectGraphType
    {
        public LessonPlanInputType()
        {
            Name = "LessonPlanInput";
            Description = "创建教案输入类型";
            Field<NonNullGraphType<StringGraphType>>(nameof(LessonPlan.LessonId), "课程Id");
            Field<IntGraphType>(nameof(LessonPlan.ToType), "教案类型");
            Field<StringGraphType>(nameof(LessonPlan.Title), "教案标题");
            Field<DateGraphType>(nameof(LessonPlan.LessonDate), "课程日期");
            Field<StringGraphType>(nameof(LessonPlan.Subject), "学科");
            Field<StringGraphType>(nameof(LessonPlan.Grade), "年级");
        }
    }
}
