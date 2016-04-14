using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class Facility
    {
        public Facility()
        {
            this.FacilityBookings = new List<FacilityBooking>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public int FacilityBookingUnitTypeId { get; set; }
        public decimal UnitRate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual FacilityBookingUnitType FacilityBookingUnitType { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<FacilityBooking> FacilityBookings { get; set; }
    }
}
