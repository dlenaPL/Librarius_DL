using Librarius_DL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarius_DL.Utilities
{
    public class DataBaseClass
    {
        public LibraryEntities db { get; set; }

        public DataBaseClass(LibraryEntities db)
        {
            this.db = db;
        }
    }
}
