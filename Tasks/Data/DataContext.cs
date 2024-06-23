using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Models;

namespace Tasks.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Csv> Csvs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddresses> EmployeesAddresses { get; set; }
        //Using ModelBuilder Creating here One to Many RelationShip between two Models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAddresses>()
            .HasOne(ea => ea.Employee)
            .WithMany(_ => _.EmployeeAddresses)
            .HasForeignKey(ea => ea.EmployeeId);
        }
        [NotMapped]
        public DbSet<Login> Logins { get; set; }
        public DbSet<Context> Contexts { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Experience> Experiences { get; set; }
    }
}
