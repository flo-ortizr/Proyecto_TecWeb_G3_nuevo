using System.ComponentModel.DataAnnotations;

namespace elearning2.Models.DTOS
{
    public record CreateLessonDto
    {
        [Required]
        public Guid CourseId { get; init; }
        [Required]
        public string Title { get; init; }
        [Required]
        public string Content { get; init; }
    }
}
