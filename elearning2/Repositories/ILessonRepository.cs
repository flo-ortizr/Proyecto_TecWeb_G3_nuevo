using elearning2.Models;

namespace elearning2.Repositories
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAll();
        Task<Lesson> GetOne(Guid id);
        Task Add(Lesson lesson);
        Task Update(Lesson lesson);
        Task Delete(Lesson lesson);
        Task<IEnumerable<Lesson>> GetByCourseId(Guid courseId);
        Task<Lesson> GetByTitle(string title);
    }
}
