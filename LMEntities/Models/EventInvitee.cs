using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class EventInvitee
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int OrganizationId { get; set; }
        public int UserId { get; set; }
        public System.DateTime NotificationSentOn { get; set; }
        public Nullable<int> RSVPId { get; set; }
        public Nullable<System.DateTime> RSVPDateTime { get; set; }
        public virtual Event Event { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual RSVPMaster RSVPMaster { get; set; }
        public virtual User User { get; set; }
    }
}
