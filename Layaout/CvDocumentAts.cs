using CV.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CV.Layaout;

public class CvDocumentAts : IDocument
{
    private readonly CVData _data;

    public CvDocumentAts(CVData data)
    {
        _data = data;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(12);

            page.DefaultTextStyle(x =>
                x.FontSize(Typography.Body)
                 .FontFamily("Arial")
                 .FontColor("#000"));

            page.Content().Column(col =>
            {
                // ================= CABECERA =================
                col.Item().Text(_data.FullName)
                    .Bold()
                    .FontSize(Typography.Title);

                col.Item().Text(_data.Title)
                    .FontSize(Typography.Subtitle);

                col.Item().PaddingTop(4);

                col.Item().Text($"Teléfono: {_data.Contact.Phone}");
                col.Item().Text($"Email: {_data.Contact.Email}");
                col.Item().Text($"GitHub: {_data.Contact.GitHub}");
                col.Item().Text($"LinkedIn: {_data.Contact.LinkedIn}");

                col.Item().PaddingVertical(8);
                col.Item().LineHorizontal(1);

                // ================= RESUMEN =================
                col.Item().PaddingTop(8);
                col.Item().Text("RESUMEN PROFESIONAL")
                    .Bold()
                    .FontSize(Typography.Section);

                col.Item().Text(_data.Profile);

                col.Item().PaddingVertical(8);
                col.Item().LineHorizontal(1);

                // ================= EXPERIENCIA =================
                col.Item().PaddingTop(8);
                col.Item().Text("EXPERIENCIA LABORAL")
                    .Bold()
                    .FontSize(Typography.Section);

                foreach (var job in _data.Jobs)
                {
                    col.Item().PaddingTop(6);

                    col.Item().Text(job.Title)
                        .Bold()
                        .FontSize(Typography.Subtitle);

                    col.Item().Text(job.Company);
                    col.Item().Text(job.Period);
                    col.Item().Text(job.Location);

                    col.Item().PaddingTop(3);

                    foreach (var task in job.Tasks)
                        col.Item().Text($"- {task}");

                    col.Item().PaddingTop(3);

                    col.Item().Text("Tecnologías: " + string.Join(", ", job.Tech));
                }

                col.Item().PaddingVertical(8);
                col.Item().LineHorizontal(1);

                // ================= EDUCACIÓN =================
                col.Item().PaddingTop(8);
                col.Item().Text("FORMACIÓN ACADÉMICA")
                    .Bold()
                    .FontSize(Typography.Section);

                foreach (var edu in _data.Education)
                {
                    col.Item().Text(edu.Title);
                    col.Item().Text(edu.Institution);
                    col.Item().PaddingTop(2);
                }

                col.Item().PaddingVertical(8);
                col.Item().LineHorizontal(1);

                // ================= HABILIDADES =================
                col.Item().PaddingTop(8);
                col.Item().Text("HABILIDADES TÉCNICAS")
                    .Bold()
                    .FontSize(Typography.Section);

                foreach (var skill in _data.Skills)
                {
                    col.Item().Text(skill.Name);
                    col.Item().Text(string.Join(", ", skill.Items));
                    col.Item().PaddingTop(2);
                }
            });
        });
    }
}