using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Models
{
    public class Lecture : DomainObject
    {
        public DateOnly Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int AudienceNumber { get; set; }
        public int TeacherId { get; set; }
        public string SubjectName { get; set; }
    }
}
