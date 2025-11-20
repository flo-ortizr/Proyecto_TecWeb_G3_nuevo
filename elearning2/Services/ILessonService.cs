using elearning2.Models;
using elearning2.Models.DTOS;

namespace elearning2.Services
{
    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> GetAll();
        Task<Lesson?> GetOne(Guid id);
        Task<Lesson> CreateLesson(CreateLessonDto dto);
        Task<Lesson> UpdateLesson(UpdateLessonDto dto, Guid id);
        Task DeleteLesson(Guid id);
        Task<IEnumerable<Lesson>> GetByCourseId(Guid courseId);
        Task<Lesson?> GetByTitle(string title);
    }
}
