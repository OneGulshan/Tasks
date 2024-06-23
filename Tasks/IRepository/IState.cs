using DataAccessLayer.Models;

namespace Tasks.IRepository
{
    public interface IState
    {
        IEnumerable<State> SGetAll();
        State SGetId(int id);
        void SUpdate(State state);
        void SDelete(State state);
        void SInsert(State state);
        void SSave();
    }
}
