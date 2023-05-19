using Diploma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.EntityFramework.Services.TeacherProviders
{
    
    public interface ITeacherService
    {
        bool AuthenticateTeacher(NetworkCredential credential);
        Teacher GetTeacherById(int id);
        Teacher GetTeacherByUsername(string username);
        List<Teacher> GetAllTeachers();
    }
}
