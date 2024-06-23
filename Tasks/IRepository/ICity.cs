using DataAccessLayer.Models;

namespace Tasks.IRepository
{
    public interface ICity
    {
        IEnumerable<City> CityGetAll();
        City CityGet(int id);
        void CityUpdate(City city);
        void CityDelete(City city);
        void cityInsert(City city);
        void citySave();
    }
}
