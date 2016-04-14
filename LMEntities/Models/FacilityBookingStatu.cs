using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class FacilityBookingStatu
    {
        public FacilityBookingStatu()
        {
            this.FacilityBookings = new List<FacilityBooking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public virtual ICollection<FacilityBooking> FacilityBookings { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
