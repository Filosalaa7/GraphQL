using School.Core.Models;

namespace School.API.Schema
{
    public class CourseTypeInput
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
