using Diploma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.EntityFramework.Services.StudentProviders
{
    public interface IStudentService
    {
        bool AuthenticateStudent(NetworkCredential credential);
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        Student GetStudentById(int id);
        Student GetStudentByUsername(string username);
        List<Student> GetAllStudents();
    }
}
