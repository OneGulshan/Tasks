using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class ContextToPdfController : Controller
    {
        private readonly DataContext _context;
        public ContextToPdfController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Contexts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Context context)
        {
            _context.Contexts.Add(context);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Contexts.Remove(_context.Contexts.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
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
