using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarius_DL.Utilities
{
    public class BooksForView
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string Publishers { get; set; }
        public string ISBN { get; set; }
        public string PublishedYear { get; set; }
        public string BookDescription { get; set; }
        public string CoverImgPath { get; set; }
        public string BookStatus { get; set; }
        public byte[] BookQRCode { get; set; }
    }
}



