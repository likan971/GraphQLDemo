using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDemo.Models.Entities
{
    public class LessonPlan
    {
        [Key]
        public string TeachingPlanId { get; set; }

        public string Title { get; set; }

        public int? ToType { get; set; }

        public string TargetId { get; set; }

        public string LessonId { get; set; }

        public DateTime? LessonDate { get; set; }

        public string LessonTime { get; set; }

        public string Subject { get; set; }

        public string Grade { get; set; }

        public string UserId { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? Status { get; set; }

        public int? PubLevel { get; set; }

        public int? DownLoadCt { get; set; }

        public string FilePath { get; set; }

        public string swfURL { get; set; }

        public string OrigiFileName { get; set; }

        public string Topical { get; set; }

        public bool? issimplemodel { get; set; }

        public int? HasHomeWork { get; set; }

        public string FlowStatus { get; set; }

        public string PreContent { get; set; }

        public string ReviewContent { get; set; }

        [ForeignKey("UserId")]
        public Teacher Teacher { get; set; }
    }
}
