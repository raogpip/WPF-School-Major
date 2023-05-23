using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Models
{
    public class Attendance
    {
        public string SubjectName { get; set; }
        public DateOnly Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
