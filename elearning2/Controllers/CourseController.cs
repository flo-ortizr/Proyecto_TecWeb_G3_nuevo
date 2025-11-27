using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using elearning2.Services;
using elearning2.Models;
using elearning2.Models.DTOS;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace elearning2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCourses()
        {
           IEnumerable<Course> courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }


        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var course = await _courseService.GetById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }


        [HttpGet("title/{title}")]
        [Authorize]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var course =  await _courseService.GetByTitle(title);
            if (course == null) return NotFound();
            return Ok(course);
        }


        [HttpGet("teacher/{teacherId}")]
        [Authorize]
        public async Task<IActionResult> GetByTeacher(Guid teacherId)
        {
            var courses = await _courseService.GetByTeacher(teacherId);
            return Ok(courses);
        }


        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> AddCourse([FromBody] CreateCourseDto dto)
        {
            if(!ModelState.IsValid) return ValidationProblem(ModelState);
            var createdCourse = await _courseService.AddCourse(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdCourse.Id }, createdCourse);
        }


        [HttpPut("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var course = await _courseService.UpdateCourse(dto, id);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }


        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _courseService.DeleteCourse(id);
            return NoContent();
        }
    }
}