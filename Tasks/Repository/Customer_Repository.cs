using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;

namespace Customerproject.Rpository
{
    public class Customer_Repository(DataContext context) : ICustomer
    {
        private readonly DataContext _context = context;
        public IEnumerable<Customer> Getall() => [.. _context.Customers.AsNoTracking()];
        public void Delete(Customer Customer) => _context.Customers.Remove(Customer);
        public Customer Get(int id) => _context.Customers.Where(x => x.Std_Id == id).FirstOrDefault();
        public void Insert(Customer Customer) => _context.Customers.Add(Customer);
        public void Save() => _context.SaveChanges();
        public void Update(Customer Customer) => _context.Customers.Update(Customer);
    }
}
