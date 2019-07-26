using GraphQL.Types;
using GraphQLDemo.Models.GraphQLTypes;
using GraphQLDemo.Services;

namespace GraphQLDemo.Models
{
    public class DemoMutation : ObjectGraphType
    {
        public DemoMutation(ILessonPlanService lessonPlanService)
        {
            Field<LessonPlanType>("CreateLessonPlan", "新建教案", lessonPlanService.GetInputArguments(), context => lessonPlanService.GetMutationResolvers(context));
        }
    }
}
