using Diploma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.EntityFramework.Services.TeacherProviders
{
    public class DatabaseTeacherService : ITeacherService
    {
        private readonly SchoolDbContextFactory _dbContextFactory;

        public DatabaseTeacherService(SchoolDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool AuthenticateTeacher(NetworkCredential credential)
        {
            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                Teacher teacher = dbContext.Teachers.SingleOrDefault(t => t.Username == credential.UserName && t.Password == credential.Password);
                return (teacher == null) ? false : true;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            using(SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Teachers.ToList();
            }
        }

        public Teacher GetTeacherById(int id)
        {
            using(SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Teachers.SingleOrDefault(t => t.Id == id); 
            }
        }

        public Teacher GetTeacherByUsername(string username)
        {
            using(SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Teachers.SingleOrDefault(t => t.Username == username);
            }
        }
    }
}
