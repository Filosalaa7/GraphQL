using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using School.Core.DTOs;

namespace School.Infrastructure.Repositories
{
    public class CoursesRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;

        public CoursesRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<CourseDTO> Create(CourseDTO course)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Courses.Add(course);
            await context.SaveChangesAsync();
            return course;
        }

        public async Task<CourseDTO> Update(CourseDTO course)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Courses.Update(course);
            await context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> Delete(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            CourseDTO course = new CourseDTO()
            {
                Id = id
            };
            context.Courses.Remove(course);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Courses.ToListAsync();
        }

        public async Task<CourseDTO> GetById(Guid courseId)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
        }

    }
}
