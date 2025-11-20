namespace elearning2.Models.DTOS
{
    public record UpdateStudentDto
    {
        public Guid? UserId { get; init; }
        public string? FullName { get; init; }
        public string? Bio { get; init; }
        public string? AvatarUrl { get; init; }
    }
}
