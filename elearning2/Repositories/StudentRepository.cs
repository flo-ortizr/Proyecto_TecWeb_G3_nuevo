using Microsoft.EntityFrameworkCore;
using elearning2.Data;
using elearning2.Models;

namespace elearning2.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _db;
        public StudentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student?> GetOne(Guid id)
        {
            return await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student?> GetByUserId(Guid userId)
        {
            return await _db.Students.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<Student?> GetByFullName(string fullName)
        {
            return await _db.Students.FirstOrDefaultAsync(x => x.FullName == fullName);
        }

        public async Task Update(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
        }
    }
}
