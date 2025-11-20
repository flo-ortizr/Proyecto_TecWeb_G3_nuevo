using System;

namespace elearning2.Models;

public class Lesson
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }  // FK
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Course Course { get; set; } = null!;
}
