using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class FacilityBookingUnitType
    {
        public FacilityBookingUnitType()
        {
            this.Facilities = new List<Facility>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
