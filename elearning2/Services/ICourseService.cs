using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using elearning2.Models;
using elearning2.Models.DTOS;

namespace elearning2.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course?> GetById(Guid courseId);
        Task<Course> AddCourse(CreateCourseDto dto);
        Task<Course?> UpdateCourse(UpdateCourseDto dto, Guid courseId);
        Task DeleteCourse(Guid courseId);
        Task<IEnumerable<Course>> GetByTeacher(Guid teacherId);
        Task<Course?> GetByTitle(string title);
    }
}