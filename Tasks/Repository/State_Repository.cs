using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;

namespace Studentproject.Repository
{
    public class State_Repository(DataContext context) : IState
    {
        private readonly DataContext _context = context;
        public void SDelete(State state) => _context.States.Remove(state);
        public IEnumerable<State> SGetAll() => [.. _context.States.AsNoTracking()];
        public State SGetId(int id) => _context.States.Where(x => x.Sid == id).FirstOrDefault();
        public void SInsert(State state) => _context.States.Add(state);
        public void SSave() => _context.SaveChanges();
        public void SUpdate(State state) => _context.States.Update(state);
    }
}
