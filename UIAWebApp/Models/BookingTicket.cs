//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UIAWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingTicket
    {
        public int BookingID { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public int AirTicketID { get; set; }
        public int FlightNumber { get; set; }
        public int AirportID { get; set; }
    
        public virtual Airport Airport { get; set; }
        public virtual AirTicketDetail AirTicketDetail { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
