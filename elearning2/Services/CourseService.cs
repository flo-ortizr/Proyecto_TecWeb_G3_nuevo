using System;
using System.Collections.Generic;
using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Repositories;

namespace elearning2.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }
        public async Task DeleteCourse(Guid courseId)
        {
            Course? course = (await GetAllCourses()).FirstOrDefault(c => c.Id == courseId);
            if (course == null) return;
            await _repo.DeleteCourse(course);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _repo.GetAll();
        }

        public async Task<Course?> GetById(Guid courseId)
        {
            return await _repo.GetById(courseId);
        }

        public async Task<IEnumerable<Course>> GetByTeacher(Guid teacherId)
        {
            return await _repo.GetByTeacher(teacherId);
        }

        public async Task<Course?> GetByTitle(string title)
        {
            return await _repo.GetByTitle(title);
        }

        public async Task<Course> AddCourse(CreateCourseDto dto)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                TeacherId = dto.TeacherId
            };
            return course;
        }

        public async Task<Course?> UpdateCourse(UpdateCourseDto dto, Guid courseId)
        {
            Course? course = await GetById(courseId);
            if (course == null) throw new Exception("Course not found");

            course.Title = dto.Title;
            course.Description = dto.Description;
            course.TeacherId = dto.TeacherId.Value;
            await _repo.UpdateCourse(course);
            return course;
        }
    }
}