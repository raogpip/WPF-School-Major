using Diploma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.EntityFramework.Services.NoteProviders
{
    public interface INoteService
    {
        List<Note> GetAllNotes();
        bool InsertNote(Note note);
        bool DeleteNote(Note note);
        bool UpdateNote(Note note);
    }
}
