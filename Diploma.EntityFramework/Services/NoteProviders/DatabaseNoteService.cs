using Diploma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.EntityFramework.Services.NoteProviders
{
    public class DatabaseNoteService : INoteService
    {
        private readonly SchoolDbContextFactory _dbContextFactory;

        public DatabaseNoteService(SchoolDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool DeleteNote(Note note)
        {
            if (note == null) return false;

            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Notes.Remove(note);
                var create = dbContext.SaveChanges();
                return create > 0;
            }
        }

        public List<Note> GetAllNotes()
        {
            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Notes.ToList();
            }
        }

        public bool InsertNote(Note note)
        {
            if (note == null) return false;

            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Notes.Add(note);
                var create = dbContext.SaveChanges();
                return create > 0;
            }
        }

        public bool UpdateNote(Note note)
        {
            if (note == null) return false;

            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Notes.Update(note);
                var create = dbContext.SaveChanges();
                return create > 0;
            }
        }
    }
}
