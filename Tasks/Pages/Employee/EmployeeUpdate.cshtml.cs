using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;

namespace Tasks;

public class EmployeeUpdate : PageModel
{
    private readonly DataContext _context;
    public EmployeeUpdate(DataContext context)
    {
        _context = context;
    }

    [BindProperty]//For Reading the form data we make this property BindProperty
    public Employee NewEmployee { get; set; } //now using this property we retrive data on razor view using, html asp-for attribute used for reading form data
    [BindProperty]
    public Employee EmployeeToUpdate { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        EmployeeToUpdate = await _context.Employee.Where(_ => _.Id == id)
        .Include(_ => _.EmployeeAddresses).FirstOrDefaultAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _context.Employee.Update(EmployeeToUpdate);//Parent/Child Both Tables Updated Here
        await _context.SaveChangesAsync();
        TempData["done"] = "Employee Updated";
        return Redirect("index");
    }
}
