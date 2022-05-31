using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer.Core.Domain;

namespace Task7.DataAccessLayer.Core.Interfaces
{
    internal interface IInfoStringFormatterService
    {
        public string GetInfoString(Student student);
    }
}
