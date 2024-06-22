using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;

namespace Tasks;

public class EmployeeDelete(DataContext context) : PageModel
{
    private readonly DataContext _context = context;

    public Employee EmployeeData { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        EmployeeData = await _context.Employees.Where(_ => _.Id == id)
        .Include(_ => _.EmployeeAddresses).FirstOrDefaultAsync();
        return Page();
    }
    public async Task<IActionResult> OnPostAsync(int id)
    {
        EmployeeData = await _context.Employees.Where(_ => _.Id == id)
        .Include(_ => _.EmployeeAddresses).FirstOrDefaultAsync();
        _context.Employees.Remove(EmployeeData);
        await _context.SaveChangesAsync();
        TempData["done"] = "Employee Deleted";
        return Redirect("index");
    }
}
