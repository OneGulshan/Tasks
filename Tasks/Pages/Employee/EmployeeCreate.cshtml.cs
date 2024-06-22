using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasks.Data;

namespace Tasks
{
    public class EmployeeCreate(DataContext context) : PageModel
    {
        private readonly DataContext _context = context;

        [BindProperty]//For Reading the form data we make this property BindProperty
        public Employee NewEmployee { get; set; } //now using this property we retrive data on razor view using, html asp-for attribute used for reading form data
        public IActionResult OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Employees.Add(NewEmployee);//This is the form field navigation property for mapping with db and inserting an record in db
            await _context.SaveChangesAsync();
            TempData["done"] = "Employee Created";
            return Redirect("index");
        }
    }
}
