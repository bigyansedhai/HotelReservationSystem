//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelResrvation.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReservationTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReservationTbl()
        {
            this.TransactionTbls = new HashSet<TransactionTbl>();
        }
    
        public int RId { get; set; }
        public string ReservationName { get; set; }
        public Nullable<System.DateTime> ReservationDate { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> RoomId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> AgentId { get; set; }
        public Nullable<int> SeasonId { get; set; }
        public Nullable<System.DateTime> CheckIn { get; set; }
        public Nullable<System.DateTime> CheckOut { get; set; }
    
        public virtual AgentTbl AgentTbl { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual BranchTbl BranchTbl { get; set; }
        public virtual CustomerTbl CustomerTbl { get; set; }
        public virtual Room Room { get; set; }
        public virtual SeasonTbl SeasonTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionTbl> TransactionTbls { get; set; }
    }
}
