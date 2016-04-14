using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class FacilityCancellation
    {
        public int FacilityBookingId { get; set; }
        public int OrganizationId { get; set; }
        public System.DateTime CanceledOn { get; set; }
        public int CanceledBy { get; set; }
        public string Reason { get; set; }
        public virtual FacilityBooking FacilityBooking { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
