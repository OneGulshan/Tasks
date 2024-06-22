using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;

namespace Tasks;

public class EmployeeDetails(DataContext context) : PageModel
{
    private readonly DataContext _context = context;

    public Employee EmployeeData { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        EmployeeData = await _context.Employees.Where(_ => _.Id == id)
        .Include(_ => _.EmployeeAddresses).FirstOrDefaultAsync();//Here Include done Join here
        return Page();
    }
}
