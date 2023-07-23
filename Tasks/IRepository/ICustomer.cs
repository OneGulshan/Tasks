using Tasks.Models;

namespace Tasks.IRepository
{
    public interface ICustomer
    {
        IEnumerable<Customer> Getall();
        Customer Get(int id);
        void Delete(Customer customer);
        void Update(Customer customer);
        void Insert(Customer customer);
        void Save();
    }
}
