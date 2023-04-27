using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Models
{
    public class Lecture : DomainObject
    {
        public DateTime Date { get; set; }
        public int AudienceNumber { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
