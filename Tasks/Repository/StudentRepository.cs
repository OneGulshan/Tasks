using MongoDB.Driver;
using DataAccessLayer.Models;

namespace Tasks.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Student> _studentTable;

        public StudentRepository()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = _mongoClient.GetDatabase("OfficeDB");
            _studentTable = _database.GetCollection<Student>("Students");
        }

        public string Delete(string studentId)
        {
            _studentTable.DeleteOne(_ => _.Id == studentId);
            return "Deleted";
        }

        public Student Get(string studentId) => _studentTable.Find(_ => _.Id == studentId).FirstOrDefault();

        public List<Student> Gets() => _studentTable.Find(FilterDefinition<Student>.Empty).ToList();

        public string Save(Student student)
        {
            var stdObj = _studentTable.Find(_ => _.Id == student.Id).FirstOrDefault();
            if (stdObj == null)
            {
                _studentTable.InsertOne(student);
                return "Save";
            }
            else
            {
                _studentTable.ReplaceOne(_ => _.Id == student.Id, student);
                return "Save";
            }
        }
    }
}
