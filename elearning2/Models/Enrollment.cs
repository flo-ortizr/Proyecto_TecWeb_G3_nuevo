using System;

namespace elearning2.Models;

public class Enrollment
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;
}
