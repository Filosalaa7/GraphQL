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
    public class InstructorRepository
    {
        private readonly SchoolDbContext _context;

        public InstructorRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<InstructorDTO> GetById(Guid instructorId)
        {
            return await _context.Instructors.FirstOrDefaultAsync(c => c.Id == instructorId);
        }

        public async Task<IEnumerable<InstructorDTO>> GetManyByIds(IReadOnlyList<Guid> instructorIds)
        {
            return await _context.Instructors
                .Where(i => instructorIds.Contains(i.Id))
                .ToListAsync();
        }
    }
}
