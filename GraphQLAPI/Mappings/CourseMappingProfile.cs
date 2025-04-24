using AutoMapper;
using School.API.Schema;
using School.Core.DTOs;

namespace School.API.Mappings
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            // Main mapping
            CreateMap<CourseDTO, CourseType>();
            CreateMap<CourseType, CourseDTO>(); // Reverse mapping

            // Optionally nested mappings if needed
            CreateMap<InstructorDTO, InstructorType>();
            CreateMap<InstructorType,InstructorDTO>(); //Reverse mapping

            CreateMap<StudentDTO, StudentType>();
            CreateMap<StudentType,StudentDTO>(); //Reverse mapping
        }
    }
}
