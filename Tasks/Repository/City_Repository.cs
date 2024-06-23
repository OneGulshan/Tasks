using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.IRepository;
using DataAccessLayer.Models;

namespace Studentproject.Repository
{
    public class City_Repository(DataContext dataContext) : ICity
    {
        private readonly DataContext _dataContext = dataContext;
        public void CityDelete(City city) => _dataContext.Cities.Remove(city);
        public City CityGet(int id) => _dataContext.Cities.Where(x => x.City_Id == id).FirstOrDefault();
        public IEnumerable<City> CityGetAll() => [.. _dataContext.Cities.AsNoTracking()];
        public void cityInsert(City city) => _dataContext.Cities.Add(city);
        public void citySave() => _dataContext.SaveChanges();
        public void CityUpdate(City city) => _dataContext.Cities.Update(city);
    }
}
