using System;

namespace Librarius_DL.Utilities
{
    public class TransactionForView
    {
        public int TransactionID { get; set; }
        public string BorrowerName { get; set; }
        public string BookTitle { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string StatusName {  get; set; }
        public string StaffName { get; set; }


    }
}
