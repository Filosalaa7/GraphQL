using AutoMapper;
using School.API.Schema;
using School.Core.DTOs;

namespace School.API.Mappings
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CourseDTO, CourseType>();
            CreateMap<CourseType, CourseDTO>();

            CreateMap<InstructorDTO, InstructorType>();
            CreateMap<InstructorType,InstructorDTO>();

            CreateMap<StudentDTO, StudentType>();
            CreateMap<StudentType,StudentDTO>(); 
        }
    }
}
