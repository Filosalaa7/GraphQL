using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Core.Models;

namespace School.Core.DTOs
{
    public class CourseDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Subject Subject { get; set; }

        public Guid InstructorId { get; set; }

        public string CreatedBy { get; set; }

        public InstructorDTO? Instructor { get; set; }

        public IEnumerable<StudentDTO>? Students { get; set; }
    }
}
