using Diploma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.EntityFramework.Services.StudentProviders
{
    public class DatabaseStudentService : IStudentService
    {
        private readonly SchoolDbContextFactory _dbContextFactory;

        public DatabaseStudentService(SchoolDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool AuthenticateStudent(NetworkCredential credential)
        {
            //bool validUser;
            //string query = "SELECT * FROM dbo.Students WHERE Username = @p0 AND Password = @p1";
            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                Student student = dbContext.Students.SingleOrDefault(s => s.Username == credential.UserName && s.Password == credential.Password);
                return (student == null) ? false : true;
            }
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByUsername(string username)
        {
            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Students.SingleOrDefault(s => s.Username == username);
            }
        }

        public void InsertStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
