namespace CV.Models;

public class SkillCategory
{
    public required string Name { get; set; }
    public List<string> Items { get; set; } = new();
}
