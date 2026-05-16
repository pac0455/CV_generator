using QuestPDF.Infrastructure;

namespace CV.Config;

public static class QuestPdfConfig
{
    public static void Init()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }
}