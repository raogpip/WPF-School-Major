using Diploma.Domain.Models;

namespace Diploma.EntityFramework.Services.NotebookProviders
{
    public class DatabaseNotebookService : INotebookService
    {
        private readonly SchoolDbContextFactory _dbContextFactory;

        public DatabaseNotebookService(SchoolDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool DeleteNotebook(Notebook notebook)
        {
            if (notebook == null)
                return false;

            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Notebooks.Remove(notebook);
                var create = dbContext.SaveChanges();
                return create > 0;
            }
        }

        public List<Notebook> GetAllNotebooks()
        {
            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Notebooks.ToList();
            }
        }

        public bool InsertNotebook(Notebook notebook)
        {
            if (notebook == null)
                return false;

            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Notebooks.Add(notebook);
                var create = dbContext.SaveChanges();
                return create > 0;
            }
        }

        public bool UpdateNotebook(Notebook notebook)
        {
            if (notebook == null)
                return false;

            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Notebooks.Update(notebook);
                var create = dbContext.SaveChanges();
                return create > 0;
            }
        }
    }
}
