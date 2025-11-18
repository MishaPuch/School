using Microsoft.EntityFrameworkCore;
using School.DAL.Model;
using School.DAL.Repositories.GenericRepository;

namespace School.DAL.Repositories
{
    public class ClassRepository : Repository<Classroom>
    {
        public ClassRepository(SchoolDbContext context) : base(context)
        {
        }

        public override async Task<Classroom?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Classrooms
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public override async Task<IEnumerable<Classroom>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Classrooms
                .Include(c => c.Students)
                .ToListAsync(ct);
        }

        public async Task AddStudentAsync(Guid classroomId, Student student, CancellationToken ct = default)
        {
            var cls = await GetByIdAsync(classroomId, ct);
            if (cls == null) throw new InvalidOperationException("Classroom not found");
            cls.AddStudent(student);
            Update(cls);
            await SaveChangesAsync(ct);
        }

        public async Task RemoveStudentAsync(Guid classroomId, Student student, CancellationToken ct = default)
        {
            var cls = await GetByIdAsync(classroomId, ct);
            if (cls == null) throw new InvalidOperationException("Classroom not found");
            cls.RemoveStudent(student);
            Update(cls);
            await SaveChangesAsync(ct);
        }
    }
}
