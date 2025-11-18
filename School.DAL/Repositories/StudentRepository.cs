using Microsoft.EntityFrameworkCore;
using School.DAL.Model;
using School.DAL.Repositories.GenericRepository;

namespace School.DAL.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(SchoolDbContext context) : base(context)
        {
		}
		public override async Task<Student?> GetByIdAsync(Guid id, CancellationToken ct = default)
		{
			return await _context.Students
				.Include(s => s.Classroom)
				.FirstOrDefaultAsync(s => s.Id == id, ct);
		}

		public override async Task<IEnumerable<Student>> GetAllAsync(CancellationToken ct = default)
		{
			return await _context.Students
				.Include(s => s.Classroom)
				.ToListAsync(ct);
		}
	}
}
