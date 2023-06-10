using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace Tasks.Controllers
{
    public class HtmltoPdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GeneratePdf(string html)
        {
            html = html.Replace("StrTag", "<").Replace("EndTag", ">");

            HtmlToPdf oHtmlToPdf = new HtmlToPdf();
            PdfDocument oPdfDocument = oHtmlToPdf.ConvertHtmlString(html);
            byte[] pdf = oPdfDocument.Save();
            oPdfDocument.Close();

            return File(
                pdf,
                "application/pdf",
                "Document.pdf"
                );
        }
    }
}
