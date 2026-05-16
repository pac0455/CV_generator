namespace CV.Models;

public class Job
{
    public required string Title { get; set; }
    public required string Company { get; set; }
    public required string Period { get; set; }
    public required string Location { get; set; }

    public List<string> Tasks { get; set; } = new();
    public List<string> Tech { get; set; } = new();
}
