using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class Organization
    {
        public Organization()
        {
            this.Events = new List<Event>();
            this.EventAddresses = new List<EventAddress>();
            this.EventComments = new List<EventComment>();
            this.EventInvitees = new List<EventInvitee>();
            this.EventMedias = new List<EventMedia>();
            this.EventTypes = new List<EventType>();
            this.Facilities = new List<Facility>();
            this.FacilityBookings = new List<FacilityBooking>();
            this.FacilityBookingStatus = new List<FacilityBookingStatu>();
            this.FacilityBookingUnitTypes = new List<FacilityBookingUnitType>();
            this.FacilityCancellations = new List<FacilityCancellation>();
            this.Leagues = new List<League>();
            this.MediaComments = new List<MediaComment>();
            this.Notifications = new List<Notification>();
            this.NotificationStatus = new List<NotificationStatu>();
            this.NotificationTypes = new List<NotificationType>();
            this.RSVPMasters = new List<RSVPMaster>();
            this.Seasons = new List<Season>();
            this.Teams = new List<Team>();
            this.Users = new List<User>();
            this.UserTypes = new List<UserType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string WorkTelephone1 { get; set; }
        public string EmailId { get; set; }
        public string Fax { get; set; }
        public string LogoLocation { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<EventAddress> EventAddresses { get; set; }
        public virtual ICollection<EventComment> EventComments { get; set; }
        public virtual ICollection<EventInvitee> EventInvitees { get; set; }
        public virtual ICollection<EventMedia> EventMedias { get; set; }
        public virtual ICollection<EventType> EventTypes { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<FacilityBooking> FacilityBookings { get; set; }
        public virtual ICollection<FacilityBookingStatu> FacilityBookingStatus { get; set; }
        public virtual ICollection<FacilityBookingUnitType> FacilityBookingUnitTypes { get; set; }
        public virtual ICollection<FacilityCancellation> FacilityCancellations { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
        public virtual ICollection<MediaComment> MediaComments { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<NotificationStatu> NotificationStatus { get; set; }
        public virtual ICollection<NotificationType> NotificationTypes { get; set; }
        public virtual ICollection<RSVPMaster> RSVPMasters { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UserType> UserTypes { get; set; }
    }
}
