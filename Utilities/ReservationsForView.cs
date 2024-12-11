using System;

namespace Librarius_DL.Utilities
{
    public class ReservationsForView
    {
        public int ReservationID { get; set; }
        public string BorrowerName { get; set; }
        public string BookTitle { get; set; }
        public DateTime? ReservationDate { get; set; }
        public string StatusName { get; set; }
    }
}
