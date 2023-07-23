using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;

namespace Studentproject.Repository
{
    public class State_Repository : IState
    {
        private readonly DataContext _context;
        public State_Repository(DataContext context)
        {
            _context = context;
        }
        public void SDelete(State state)
        {
            _context.States.Remove(state);
        }

        public IEnumerable<State> SGetAll()
        {
            return _context.States.ToList();
        }

        public State SGetId(int id)
        {
            return _context.States.Where(x => x.Sid == id).FirstOrDefault();
        }

        public void SInsert(State state)
        {
            _context.States.Add(state);
        }

        public void SSave()
        {
            _context.SaveChanges();
        }

        public void SUpdate(State state)
        {
            _context.States.Update(state);
        }
    }
}
