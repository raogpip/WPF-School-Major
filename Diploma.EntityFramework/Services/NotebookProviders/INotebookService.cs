using Diploma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.EntityFramework.Services.NotebookProviders
{
    public interface INotebookService
    {
        List<Notebook> GetAllNotebooks();
        bool InsertNotebook(Notebook notebook);
        bool DeleteNotebook(Notebook notebook);
        bool UpdateNotebook(Notebook notebook);

    }
}
