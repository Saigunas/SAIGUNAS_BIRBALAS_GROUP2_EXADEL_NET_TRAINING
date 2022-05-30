using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.DataAccessLayer.Core.Domain
{
    public class ClassSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Class Class { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
