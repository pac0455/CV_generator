using CV.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class CVDocumentPretty : IDocument
{
    private readonly CVData _data;

    public CVDocumentPretty(CVData data)
    {
        _data = data;
    }

    // ================= DESIGN SYSTEM =================
    private static class Typography
    {
        public const float Body = 10;
        public const float Small = 9;
        public const float Section = 13;
        public const float Subtitle = 11;
        public const float Title = 24;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(18);

            page.DefaultTextStyle(x =>
                x.FontFamily("Segoe UI")
                 .FontSize(Typography.Body)
                 .FontColor("#333"));

            page.Content().Column(col =>
            {
                // ================= HEADER =================
                col.Item().AlignCenter().Column(header =>
                {
                    header.Item().Text(_data.FullName)
                        .FontSize(Typography.Title)
                        .Bold()
                        .FontColor("#1a1a2e");

                    header.Item().Text(_data.Title)
                        .FontSize(Typography.Section)
                        .FontColor("#444");

                    header.Item().PaddingTop(2);

                    header.Item().Text(
                        $"{_data.Contact.Phone} | {_data.Contact.Email}"
                    ).FontSize(Typography.Small);

                    header.Item().Text(
                        $"{_data.Contact.GitHub} | {_data.Contact.LinkedIn}"
                    )
                    .FontSize(Typography.Small)
                    .FontColor("#666");
                });

                col.Item().PaddingVertical(6);
                col.Item().LineHorizontal(1).LineColor("#eaeaea");
                col.Item().PaddingVertical(6);

                // ================= PERFIL =================
                col.Item().Text("RESUMEN PROFESIONAL")
                    .FontSize(Typography.Section)
                    .Bold()
                    .FontColor("#0f3460");

                col.Item().PaddingTop(3);

                col.Item().Text(_data.Profile)
                    .FontSize(Typography.Body)
                    .LineHeight(1.2f);

                col.Item().PaddingVertical(6);
                col.Item().LineHorizontal(1).LineColor("#eaeaea");
                col.Item().PaddingVertical(6);

                // ================= EXPERIENCIA =================
                col.Item().Text("EXPERIENCIA LABORAL")
                    .FontSize(Typography.Section)
                    .Bold()
                    .FontColor("#0f3460");

                foreach (var job in _data.Jobs)
                {
                    col.Item().PaddingTop(6);

                    col.Item().Background("#f8f9fb")
                        .Border(1)
                        .BorderColor("#e6e6e6")
                        .Padding(8)
                        .Column(jobCard =>
                        {
                            jobCard.Item().Text($"{job.Title} — {job.Company}")
                                .FontSize(Typography.Subtitle)
                                .Bold();

                            jobCard.Item().Text($"{job.Period} | {job.Location}")
                                .FontSize(Typography.Small)
                                .FontColor("#666");

                            jobCard.Item().PaddingTop(3);

                            jobCard.Item().Text("• " + string.Join("\n• ", job.Tasks))
                                .FontSize(Typography.Body);

                            jobCard.Item().PaddingTop(3);

                            jobCard.Item().Text(string.Join(", ", job.Tech))
                                .FontSize(Typography.Body)
                                .FontColor("#333");
                        });
                }

                col.Item().PaddingVertical(6);
                col.Item().LineHorizontal(1).LineColor("#eaeaea");
                col.Item().PaddingVertical(6);

                // ================= EDUCACIÓN =================
                col.Item().Text("EDUCACIÓN")
                    .FontSize(Typography.Section)
                    .Bold()
                    .FontColor("#0f3460");

                foreach (var e in _data.Education)
                {
                    col.Item().Text($"• {e.Title} ({e.Institution})")
                        .FontSize(Typography.Body);
                }

                col.Item().PaddingVertical(6);
                col.Item().LineHorizontal(1).LineColor("#eaeaea");
                col.Item().PaddingVertical(6);

                // ================= SKILLS =================
                col.Item().Text("HABILIDADES TÉCNICAS")
                    .FontSize(Typography.Section)
                    .Bold()
                    .FontColor("#0f3460");

                col.Item().PaddingTop(3);

                foreach (var cat in _data.Skills)
                {
                    col.Item().Text(
                        $"{cat.Name}: {string.Join(", ", cat.Items)}"
                    )
                    .FontSize(Typography.Body);
                }
            });
        });
    }
}