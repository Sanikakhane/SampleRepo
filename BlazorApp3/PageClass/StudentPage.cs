using BlazorApp3.Data;
using BlazorApp3.IService;

namespace BlazorApp3.PageClass
{
    public class StudentPage
    {
        IStudentService _studentService = null;

        public StudentPage(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public string SaveInformation(byte[] fileBytes,Student student)
        {
            student.Photo = fileBytes;
            return _studentService.Save(student);
        }
        public Student GetStudent(string studentId)
        {
            var student = _studentService.GetStudent(studentId);
            student.Photo = this.GetImage(Convert.ToBase64String(student.Photo));
            student.ImageUrl = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(student.Photo));
            return student;
        }
        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if(!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);    

            }
            return bytes;
        }
    }
}
