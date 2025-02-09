using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
