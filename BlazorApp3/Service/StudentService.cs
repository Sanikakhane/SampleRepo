using BlazorApp3.Data;
using BlazorApp3.IService;
using MongoDB.Driver;

namespace BlazorApp3.Service
{
    public class StudentService : IStudentService
    {
        Student _oStudent = new Student();

        private IMongoClient? _mongoClient=null;
        private IMongoDatabase? _database=null;
        private IMongoCollection<Student>? _studentTable = null;

        public StudentService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:30115/");
            _database = _mongoClient.GetDatabase("SchoolDB");
            _studentTable = _database.GetCollection<Student>("Students");
        }
        public Student GetStudent(string studentId)
        {
            return _studentTable.Find(x=>x.Id == studentId).FirstOrDefault();
        }

        public List<Student> GetStudents()
        {
            return _studentTable.Find(FilterDefinition<Student>.Empty).ToList();
        }

        public string Save(Student student)
        {
            Student studentObj = _studentTable.Find(x=> x.Id == student.Id).FirstOrDefault();
            if(studentObj == null)
            {
                _studentTable.InsertOne(student);
            }
            else
            {
                _studentTable.ReplaceOne(x=>x.Id==student.Id,student);
            }
            return "Sucess";
        }
    }
}
