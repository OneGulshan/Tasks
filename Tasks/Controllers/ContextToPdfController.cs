using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class ContextToPdfController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

        public IActionResult Index() => View(_context.Contexts.ToList());

        public IActionResult Create(int id)
        {
            if (id > 0)
            {
                ViewBag.BT = "Update";
                return View(_context.Contexts.Where(x => x.Id == id).FirstOrDefault());
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Context context)
        {
            if(context.Id > 0)
            {
                var Record = _context.Contexts.Where(x => x.Id == context.Id).FirstOrDefault();
                Record.Name = context.Name;
                Record.Enrolled = context.Enrolled;
                _context.Update(Record);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
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

            HtmlToPdf oHtmlToPdf = new();
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
