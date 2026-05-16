namespace CV.Config;

public class AppConfig
{
    public bool DevMode { get; set; }

    public string Theme { get; set; } = "ATS";

    public string CvFile { get; set; } = "Template/base.json";

    public string OutputDir { get; set; } = "output";

    public string OutputPdf { get; set; } = "cv.pdf";

    public string OutputJson { get; set; } = "base.json";
}