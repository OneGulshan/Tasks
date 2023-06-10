using MongoDB.Driver;
using Tasks.Models;

namespace Tasks.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _database;
        private IMongoCollection<Student> _studentTable;

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

        public Student Get(string studentId)
        {
            return _studentTable.Find(_ => _.Id == studentId).FirstOrDefault();
        }

        public List<Student> Gets()
        {
            return _studentTable.Find(FilterDefinition<Student>.Empty).ToList();
        }

        public string Save(Student student)
        {
            var stdObj = _studentTable.Find(_ => _.Id == student.Id).FirstOrDefault();
            if(stdObj == null)
            {
                _studentTable.InsertOne(student);
            }
            else
            {
                _studentTable.ReplaceOne(_ => _.Id == student.Id, student);
            }
            return "Save";
        }
    }
}
