using AutoMapper;
using School.Core.DTOs;
using School.Infrastructure;
using School.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



namespace School.API.Schema
{
    public class Queries
    {
        private readonly CoursesRepository _coursesRepository;
        private readonly IMapper _mapper;

        public Queries(CoursesRepository coursesRepository, IMapper mapper)
        {
            _coursesRepository = coursesRepository;
            _mapper = mapper;
        }


        [Authorize(Roles = "User")]
        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<CourseType> GetOffsetCourses(
        [Service] IDbContextFactory<SchoolDbContext> dbContextFactory,
        [Service] IMapper mapper)
        {
            var context = dbContextFactory.CreateDbContext();
            var courseDtos = context.Courses.AsQueryable();
            return mapper.ProjectTo<CourseType>(courseDtos); 
        }


        [Authorize(Roles = "User")]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        [UseSorting]
        public async Task<IEnumerable<CourseType>> GetAllCourses()
        {
            var courseDtos = await _coursesRepository.GetAll();
            return _mapper.Map<IEnumerable<CourseType>>(courseDtos);
        }

        [Authorize(Roles = "User")]
        public async Task<CourseType> GetCourseById(Guid id)
        {
            var courseDto = await _coursesRepository.GetById(id);
            return _mapper.Map<CourseType>(courseDto);
        }

        
    }
}
