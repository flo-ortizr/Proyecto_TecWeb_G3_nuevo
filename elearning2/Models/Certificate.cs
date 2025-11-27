using elearning2.Models;

public class Certificate
{
    public Guid Id { get; set; }
    public Guid? StudentId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Student? Student { get; set; }
}
