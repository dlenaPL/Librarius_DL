//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Librarius_DL.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notifications
    {
        public int NotificationID { get; set; }
        public Nullable<int> BorrowerID { get; set; }
        public Nullable<int> BookID { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> DateSent { get; set; }
        public Nullable<bool> IsRead { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Members Members { get; set; }
    }
}
