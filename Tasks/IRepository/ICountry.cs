using Tasks.Models;

namespace Tasks.IRepository
{
    public interface ICountry
    {
        IEnumerable<Country> CGetall();
        Country CGet(int id);
        void CDelete(Country country);
        void CUpdate(Country country);
        void CInsert(Country country);
        void CSave();
    }
}
