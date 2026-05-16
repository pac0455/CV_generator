using CV.Models;

namespace CV.Models;

public class CVData
{
    public string FullName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public ContactInfo Contact { get; set; } = new();

    public string Profile { get; set; } = string.Empty;

    public List<Job> Jobs { get; set; } = new();

    public List<Education> Education { get; set; } = new();

    public List<SkillCategory> Skills { get; set; } = new();
}