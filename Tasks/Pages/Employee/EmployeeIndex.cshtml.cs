using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;

namespace Tasks
{
    public class EmployeeIndex : PageModel
    {
        private readonly DataContext _context;
        public EmployeeIndex(DataContext context)
        {
            _context = context;
        }

        public List<Employee> AllEmployee { get; set; }
        public async Task<IActionResult> OnGetAsync() //These are the life cycle methods.
        {
            AllEmployee = await _context.Employee.ToListAsync();
            return Page();
        }
    }
}