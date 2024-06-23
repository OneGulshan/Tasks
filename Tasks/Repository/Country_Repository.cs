using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.IRepository;
using DataAccessLayer.Models;

namespace Studentproject.Repository
{
    public class Country_Repository(DataContext context) : ICountry
    {
        private readonly DataContext _Context = context;
        public void CDelete(Country country) => _Context.Countries.Remove(country);
        public Country CGet(int id) => _Context.Countries.Where(x => x.Cid == id).FirstOrDefault();
        public IEnumerable<Country> CGetall() => [.. _Context.Countries.AsNoTracking()];
        public void CInsert(Country country) => _Context.Countries.Add(country);
        public void CSave() => _Context.SaveChanges();
        public void CUpdate(Country country) => _Context.Countries.Update(country);
    }
}
