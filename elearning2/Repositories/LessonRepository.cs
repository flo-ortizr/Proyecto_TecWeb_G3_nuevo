using Microsoft.EntityFrameworkCore;
using elearning2.Data;
using elearning2.Models;

namespace elearning2.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _db;
        public LessonRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Lesson lesson)
        {
            await _db.Lessons.AddAsync(lesson);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            return await _db.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetOne(Guid id)
        {
            return await _db.Lessons.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Update(Lesson lesson)
        {
            _db.Lessons.Update(lesson);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(Lesson lesson)
        {
            _db.Lessons.Remove(lesson);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lesson>> GetByCourseId(Guid courseId)
        {
            return await _db.Lessons.Where(l => l.CourseId == courseId).ToListAsync();
        }

        public async Task<Lesson> GetByTitle(string title)
        {
            return await _db.Lessons.FirstOrDefaultAsync(l => l.Title == title);
        }

    }
}
