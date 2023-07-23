using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;

namespace Studentproject.Repository
{
    public class City_Repository : ICity
    {
        private readonly DataContext _dataContext;

        public City_Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CityDelete(City city)
        {
            _dataContext.Cities.Remove(city);
        }

        public City CityGet(int id)
        {
            return _dataContext.Cities.Where(x => x.City_Id == id).FirstOrDefault();
        }

        public IEnumerable<City> CityGetAll()
        {
            return _dataContext.Cities.ToList();
        }

        public void cityInsert(City city)
        {
            _dataContext.Cities.Add(city);
        }

        public void citySave()
        {
            _dataContext.SaveChanges();
        }

        public void CityUpdate(City city)
        {
            _dataContext.Cities.Update(city);
        }
    }
}
