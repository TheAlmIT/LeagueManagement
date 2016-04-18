using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMEntities.Models
{
    public partial class User :Entity
    {
        public User()
        {
            this.Events = new List<Event>();
            this.Events1 = new List<Event>();
            this.Events2 = new List<Event>();
            this.EventComments = new List<EventComment>();
            this.EventComments1 = new List<EventComment>();
            this.EventInvitees = new List<EventInvitee>();
            this.EventMedias = new List<EventMedia>();
            this.EventMedias1 = new List<EventMedia>();
            this.Facilities = new List<Facility>();
            this.Facilities1 = new List<Facility>();
            this.FacilityBookings = new List<FacilityBooking>();
            this.FacilityBookings1 = new List<FacilityBooking>();
            this.MatchResults = new List<MatchResult>();
            this.MatchResults1 = new List<MatchResult>();
            this.MediaComments = new List<MediaComment>();
            this.MediaComments1 = new List<MediaComment>();
            
            this.Teams = new List<Team>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public Nullable<int> UserTypeId { get; set; }
        [DisplayName("Email ID")]
        public string EmailId { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Password { get; set; }     
        public string UserName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
        public Nullable<int> GenderId { get; set; }
        public string ProfilePhoto { get; set; }
        public string NickName { get; set; }
        [DisplayName("Skill")]
        public Nullable<int> SkillSpecialityId { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string PlaceofBirth { get; set; }
        public Nullable<int> LivedInUSAsince { get; set; }
        public string SchoolName { get; set; }
        public string Grade { get; set; }
        public string BattingStyle { get; set; }
        public string FavouriteShot { get; set; }
        public string BowlingStyle { get; set; }
        public string FavoriteCricketer { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string FavouriteFood { get; set; }
        public string FavouriteMovie { get; set; }
        public string Ambition { get; set; }
        public string Hobbies { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Event> Events1 { get; set; }
        public virtual ICollection<Event> Events2 { get; set; }
        public virtual ICollection<EventComment> EventComments { get; set; }
        public virtual ICollection<EventComment> EventComments1 { get; set; }
        public virtual ICollection<EventInvitee> EventInvitees { get; set; }
        public virtual ICollection<EventMedia> EventMedias { get; set; }
        public virtual ICollection<EventMedia> EventMedias1 { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<Facility> Facilities1 { get; set; }
        public virtual ICollection<FacilityBooking> FacilityBookings { get; set; }
        public virtual ICollection<FacilityBooking> FacilityBookings1 { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<MatchResult> MatchResults { get; set; }
        public virtual ICollection<MatchResult> MatchResults1 { get; set; }
        public virtual ICollection<MediaComment> MediaComments { get; set; }
        public virtual ICollection<MediaComment> MediaComments1 { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        public virtual SkillSpeciality SkillSpeciality { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
       
        public virtual UserType UserType { get; set; }

        [NotMapped]
        [DisplayName("Umpires")]
        public string Umpire { get; set; }

        
        public string AspNetUsersId { get; set; }

        [NotMapped]
        public virtual ICollection<User> Umpires { get; set; }
    }
}
