using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Repositories;

namespace elearning2.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Student> CreateStudent(CreateStudentDto dto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                FullName = dto.FullName,
                Bio = dto.Bio,
                AvatarUrl = dto.AvatarUrl
            };
            await _repo.Add(student);
            return student;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Student?> GetOne(Guid id)
        {
            var student = await _repo.GetOne(id);
            if (student == null) throw new Exception($"Student with ID {id} does not exist.");
            return student;
        }

        public async Task<Student?> GetByUserId(Guid userId)
        {
            var student = await _repo.GetByUserId(userId);
            if (student == null) throw new Exception($"Student with UserId {userId} not found.");
            return student;
        }

        public async Task<Student?> GetByFullName(string fullName)
        {
            var student = await _repo.GetByFullName(fullName);
            if (student == null) throw new Exception($"Student with full name '{fullName}' not found.");
            return student;
        }

        public async Task Add(Student student)
        {
            await _repo.Add(student);
        }

        public async Task Update(Student student)
        {
            Student? existing = await _repo.GetOne(student.Id);
            if (existing == null) throw new Exception($"Student with ID {student.Id} does not exist.");
            await _repo.Update(student);
        }

        public async Task Delete(Student student)
        {
            Student? existing = await _repo.GetOne(student.Id);
            if (existing == null) throw new Exception($"Student with ID {student.Id} does not exist.");
            await _repo.Delete(student);
        }
    }
}
