using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Models
{
    public class Notebook : DomainObject
    {
        public int UserId { get; set; }
        public string Name { get; set; }    
    }
}
