using DataAccessLayer.Models;

namespace Tasks.Repository
{
    public interface IStudentRepository
    {
        string Save(Student employe);
        Student Get(string employeId);
        List<Student> Gets();
        string Delete(string employeeId);
    }
}
