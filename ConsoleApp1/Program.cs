using Diploma.Domain.Models;
using Diploma.Domain.Services;
using Diploma.EntityFramework;
using Diploma.EntityFramework.Services;

IDataService<Student> userService = new GenericDataService<Student>(new SchoolDbContextFactory());

Console.WriteLine(userService.Delete(1).Result);
