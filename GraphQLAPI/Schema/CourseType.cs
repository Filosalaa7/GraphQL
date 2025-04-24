using AutoMapper;
using School.API.DataLoaders;
using School.Core.Models;
using School.Infrastructure.Repositories;

namespace School.API.Schema
{
    public class CourseType
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Subject Subject { get; set; }
        [IsProjected(true)]
        public Guid InstructorId { get; set; }

        public string CreatedBy { get; set; }


        [GraphQLNonNullType]

        public async Task<InstructorType> Instructor(
            [Service] InstructorDataLoader instructorDataLoader,
            [Service] IMapper mapper)
        { 
           var instuctorDto =  await instructorDataLoader.LoadAsync(InstructorId);
            return mapper.Map<InstructorType>(instuctorDto);
        }
        public IEnumerable<StudentType>? Students { get; set; }
    }
}
