using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class Event
    {
        public Event()
        {
            this.EventAddresses = new List<EventAddress>();
            this.EventComments = new List<EventComment>();
            this.EventInvitees = new List<EventInvitee>();
            this.EventMedias = new List<EventMedia>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        public int HostId { get; set; }
        public int TypeId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public Nullable<int> HomeTeamId { get; set; }
        public Nullable<int> VisitorTeamId { get; set; }
        public string ContactPhoneNumber1 { get; set; }
        public string ContactPhoneNumber2 { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Team Team { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual ICollection<EventAddress> EventAddresses { get; set; }
        public virtual ICollection<EventComment> EventComments { get; set; }
        public virtual ICollection<EventInvitee> EventInvitees { get; set; }
        public virtual ICollection<EventMedia> EventMedias { get; set; }
    }
}
