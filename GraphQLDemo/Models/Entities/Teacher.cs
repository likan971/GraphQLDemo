using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Models.Entities
{
    public class Teacher
    {
        [Key]
        public string UserId { get; set; }

        public string DisplayName { get; set; }

        public string HrCode { get; set; }

        public string WorkLocation { get; set; }

        public string Grade { get; set; }

        public string Course { get; set; }

        public string PositionName { get; set; }

        public virtual ICollection<LessonPlan> LessonPlans { get; set; }
    }
}
