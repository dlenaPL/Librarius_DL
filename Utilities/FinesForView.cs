using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarius_DL.Utilities
{
    public class FinesForView
    {
        public int? FineID { get; set; }
        public int? TransactionID { get; set; }
        public decimal FineAmount { get; set; }
        public DateTime? PaidDate { get; set; }
        public string FineStatusName {  get; set; } 
    }
}
