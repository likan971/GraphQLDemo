using GraphQL.Types;
using GraphQLDemo.Models.Entities;

namespace GraphQLDemo.Models.GraphQLTypes
{
    public class EmpInfoType : ObjectGraphType<BP_EmpInfo>
    {
        public EmpInfoType()
        {
            Name = "EmpInfo";
            Description = "员工明细";
            Field<DateTimeGraphType>(nameof(BP_EmpInfo.Date), "日期");
            Field<StringGraphType>(nameof(BP_EmpInfo.Event), "事件");
            Field<NonNullGraphType<StringGraphType>>(nameof(BP_EmpInfo.Name), "姓名");
            Field<StringGraphType>(nameof(BP_EmpInfo.Department), "部门");
            Field<StringGraphType>(nameof(BP_EmpInfo.Job), "职位");
            Field<IntGraphType>(nameof(BP_EmpInfo.JobGrade), "职级");
        }
    }
}
