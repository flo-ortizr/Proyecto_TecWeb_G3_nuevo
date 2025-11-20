using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Services;

namespace elearning2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetAllStudents([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            try
            {
                var students = await _service.GetAll();
                var pagedStudents = students.Skip((page - 1) * limit).Take(limit);
                return Ok(new { Students = pagedStudents, Page = page, Limit = limit, Total = students.Count() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving students.", Details = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            try
            {
                var student = await _service.GetOne(id);
                if (student == null)
                {
                    return NotFound(new { Message = "Student not found." });
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the student.", Details = ex.Message });
            }
        }

        [HttpGet("user/{userId:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetStudentByUserId(Guid userId)
        {
            try
            {
                var student = await _service.GetByUserId(userId);
                if (student == null)
                {
                    return NotFound(new { Message = "Student not found for the given user ID." });
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the student by user ID.", Details = ex.Message });
            }
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> GetStudentByFullName([FromQuery] string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return BadRequest(new { Message = "Full name is required for search." });
            }
            try
            {
                var student = await _service.GetByFullName(fullName);
                if (student == null)
                {
                    return NotFound(new { Message = "Student not found with the given full name." });
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while searching for the student.", Details = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    UserId = dto.UserId,
                    FullName = dto.FullName,
                    Bio = dto.Bio,
                    AvatarUrl = dto.AvatarUrl
                };
                await _service.Add(student);
                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the student.", Details = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDto dto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                var existingStudent = await _service.GetOne(id);
                if (existingStudent == null)
                {
                    return NotFound(new { Message = "Student not found." });
                }
                existingStudent.FullName = dto.FullName;
                existingStudent.Bio = dto.Bio;
                existingStudent.AvatarUrl = dto.AvatarUrl;
                await _service.Update(existingStudent);
                return Ok(existingStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the student.", Details = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                var student = await _service.GetOne(id);
                if (student == null)
                {
                    return NotFound(new { Message = "Student not found." });
                }
                await _service.Delete(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the student.", Details = ex.Message });
            }
        }
    }
}
