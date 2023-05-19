using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.EntityFramework
{
    public class SchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
    {
        public SchoolDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>();
            options.UseSqlServer("Server=.;Database=DiplomaDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");
            return new SchoolDbContext(options.Options);    
        }
    }
}
    