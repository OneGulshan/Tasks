using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;

namespace Studentproject.Repository
{
    public class Country_Repository : ICountry
    {
        private readonly DataContext _Context;

        public Country_Repository(DataContext context)
        {
            _Context = context;
        }

        public void CDelete(Country country)
        {
            _Context.Countries.Remove(country);
        }

        public Country CGet(int id)
        {
            return _Context.Countries.Where(x => x.Cid == id).FirstOrDefault();
        }

        public IEnumerable<Country> CGetall()
        {
            return _Context.Countries.ToList();
        }

        public void CInsert(Country country)
        {
            _Context.Countries.Add(country);
        }

        public void CSave()
        {
            _Context.SaveChanges();
        }

        public void CUpdate(Country country)
        {
            _Context.Countries.Update(country);
        }
    }
}
