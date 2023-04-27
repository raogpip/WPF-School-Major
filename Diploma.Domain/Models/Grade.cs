using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Models
{
    public class Grade : DomainObject
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int GradeValue { get; set; } 
    }
}
