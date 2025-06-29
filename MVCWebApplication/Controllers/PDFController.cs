using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

public class PdfController : Controller
{
    public IActionResult GeneratePdf()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, ms);
            document.Open();
            document.Add(new Paragraph("Hello, this is a customized PDF!"));
            document.Close();

            return File(ms.ToArray(), "application/pdf", "CustomDocument.pdf");
        }
    }
}