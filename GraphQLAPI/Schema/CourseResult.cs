using School.Core.Models;

namespace School.API.Schema
{
    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }

        public string CreatedBy { get; set; } // Add this field to track who created it
    }
}
