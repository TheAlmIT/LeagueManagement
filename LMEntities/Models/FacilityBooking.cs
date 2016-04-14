using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class FacilityBooking
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int FacilityId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public int StatusId { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual FacilityBookingStatu FacilityBookingStatu { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual FacilityCancellation FacilityCancellation { get; set; }
    }
}
