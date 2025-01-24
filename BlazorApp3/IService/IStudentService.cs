using BlazorApp3.Data;

namespace BlazorApp3.IService
{
    public interface IStudentService
    {
        string Save(Student student);
        List<Student> GetStudents();
        Student GetStudent(string studentId);
    }
}
