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
    
    public partial class BranchTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BranchTbl()
        {
            this.ReservationTbls = new HashSet<ReservationTbl>();
            this.Rooms = new HashSet<Room>();
        }
    
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public Nullable<int> HotelId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<decimal> PhoneNumber { get; set; }
    
        public virtual HotelStatu HotelStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationTbl> ReservationTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
