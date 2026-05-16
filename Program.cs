using CV.Config;
using CV.IO;
using CV.Layaout;
using Microsoft.Extensions.Configuration;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        QuestPdfConfig.Init();

        // Cargar configuración
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var config = configuration
            .GetSection("Cv")
            .Get<AppConfig>()!;

        // Cargar datos CV
        var loader = new JsonLoader();
        var data = loader.Load(config.CvFile);

        // Selección de layout
        IDocument cv = config.Theme.ToUpper() == "PRETTY"
            ? new CVDocumentPretty(data)
            : new CvDocumentAts(data);

        // Crear output dir
        Directory.CreateDirectory(config.OutputDir);

        var outputPdf = Path.Combine(
            config.OutputDir,
            config.OutputPdf
        );

        // DEV MODE
        if (config.DevMode)
        {
            cv.ShowInCompanion();
            return;
        }

        // Generar PDF
        cv.GeneratePdf(outputPdf);

        Console.WriteLine($"PDF generado en: {outputPdf}");
    }
}