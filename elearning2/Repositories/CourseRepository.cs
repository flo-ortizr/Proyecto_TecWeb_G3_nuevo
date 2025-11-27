using Microsoft.EntityFrameworkCore;
using elearning2.Data;
using elearning2.Models;

namespace elearning2.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _db;
        public CourseRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddCourse(Course course)
        {
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCourse(Course course)
        {
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course?> GetById(Guid courseId)
        {
            return await _db.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<IEnumerable<Course>> GetByTeacher(Guid teacherId)
        {
            return await _db.Courses.Where(c => c.TeacherId == teacherId).ToListAsync();
        }

        public async Task<Course?> GetByTitle(string title)
        {
            return await _db.Courses.FirstOrDefaultAsync(c => c.Title == title);
        }

        public async Task UpdateCourse(Course course)
        {
            _db.Courses.Update(course);
            await _db.SaveChangesAsync();
        }
    }
}