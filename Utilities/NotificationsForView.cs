using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarius_DL.Utilities
{
    public class NotificationsForView
    {
        public int NotificationID { get; set; }
        public string BorrowersName { get; set; }
        public string BookTitle { get; set; }
        public string Message { get; set; }
        public DateTime? DateSent { get; set; }
        public bool? IsRead { get; set; }
    }
}
