using elearning2.Models;

namespace elearning2.Repositories
{
   public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course?> GetById(Guid courseId);
        Task AddCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(Course course);
        Task<Course?> GetByTitle(string title);
        Task<IEnumerable<Course>> GetByTeacher(Guid teacherId);
    }
}