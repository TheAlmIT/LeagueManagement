using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class RSVPMaster
    {
        public RSVPMaster()
        {
            this.EventInvitees = new List<EventInvitee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public virtual ICollection<EventInvitee> EventInvitees { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
