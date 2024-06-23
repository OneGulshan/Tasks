using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;

namespace TasksAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployees(Employee employee)
        {
            var result = await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;//Entity <- This Entity is model our saved result tracked by this Entity and auto get our data for displaing on browser with the help of this auto tracking Entity.
        }

        public async Task<Employee> DeleteEmployee(int Id)
        {
            var result = await _context.Employee.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Employee.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            return await _context.Employee.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Employee> UpdateEmployees(Employee employee)
        {
            var result = await _context.Employee.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (result != null)
            {
                result.Name = employee.Name;
                result.City = employee.City;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> Search(string name)
        {
            IQueryable<Employee> query = _context.Employee;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.Contains(name));//Contains for deep searching
            }
            return await query.ToListAsync();
        }
    }
}
