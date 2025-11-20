using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Repositories;

namespace elearning2.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _repo;
        public LessonService(ILessonRepository repo)
        {
            _repo = repo;
        }
        public async Task<Lesson> CreateLesson(CreateLessonDto dto)
        {
            var lesson = new Lesson
            {
                Id = Guid.NewGuid(),
                CourseId = dto.CourseId,
                Title = dto.Title,
                Content = dto.Content,
                CreatedAt = DateTime.UtcNow
            };
            await _repo.Add(lesson);
            return lesson;
        }

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Lesson?> GetOne(Guid id)
        {
            try
            {
                return await _repo.GetOne(id);
            }
            catch
            {
                return null;
            }
        }
        public async Task<Lesson> UpdateLesson(UpdateLessonDto dto, Guid id)
        {
            Lesson? lesson = await GetOne(id);
            if (lesson == null) throw new Exception($"Lesson with ID {id} does not exist.");

            if (dto.CourseId.HasValue) lesson.CourseId = dto.CourseId.Value;
            if (dto.Title != null) lesson.Title = dto.Title;
            if (dto.Content != null) lesson.Content = dto.Content;

            await _repo.Update(lesson);
            return lesson;
        }
        public async Task DeleteLesson(Guid id)
        {
            Lesson? lesson = await GetOne(id);
            if (lesson == null) return;
            await _repo.Delete(lesson);
        }

        public async Task<IEnumerable<Lesson>> GetByCourseId(Guid courseId)
        {
            return await _repo.GetByCourseId(courseId);
        }

        public async Task<Lesson?> GetByTitle(string title)
        {
            try
            {
                return await _repo.GetByTitle(title);
            }
            catch
            {
                return null;
            }
        }
    }
}
