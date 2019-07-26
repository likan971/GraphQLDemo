using System;

namespace GraphQLDemo.Models.Requests
{
    public class LessonPlanRequest
    {
        public string LessonId { get; set; }

        public int ToType { get; set; }

        public string Title { get; set; }

        public DateTime LessonDate { get; set; }

        public string Subject { get; set; }

        public string Grade { get; set; }
    }
}
