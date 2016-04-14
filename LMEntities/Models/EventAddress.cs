using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class EventAddress
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCd { get; set; }
        public string LandMark { get; set; }
        public virtual Event Event { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
