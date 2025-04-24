using AutoMapper;
using School.API.DataLoaders;

namespace School.API.Schema
{
    public class InstructorType
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public double Salary { get; set; }
        [IsProjected(true)]
        public Guid CourseId { get; set; }
    }
}
