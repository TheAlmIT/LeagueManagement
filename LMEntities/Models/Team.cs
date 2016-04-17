using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMEntities.Models
{
    public partial class Team : Repository.Pattern.Ef6.Entity
    {
        public Team()
        {
            this.Events = new List<Event>();
            this.Events1 = new List<Event>();
            this.MatchResults = new List<MatchResult>();
            this.MatchResults1 = new List<MatchResult>();
            this.MatchResults2 = new List<MatchResult>();
            this.MatchResults3 = new List<MatchResult>();
            this.TeamManagements = new List<TeamManagement>();
            this.TeamMembers = new List<TeamMember>();
        }

        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Organization Name")]
        public int OrganizationId { get; set; }
        [Required]
        [DisplayName("Nick Name")]
        public string NickName { get; set; }
 
        public string Description { get; set; }
        [DisplayName("Team Photo")]
        public string PhotoUrl { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Event> Events1 { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Schedule> Schedules1 { get; set; }
        public virtual ICollection<MatchResult> MatchResults { get; set; }
        public virtual ICollection<MatchResult> MatchResults1 { get; set; }
        public virtual ICollection<MatchResult> MatchResults2 { get; set; }
        public virtual ICollection<MatchResult> MatchResults3 { get; set; }
        public virtual Organization Organization { get; set; }
        [NotMapped]
        public virtual ICollection<Organization> Organizations { get; set; } 
        public virtual User User { get; set; }
        [NotMapped]
        public virtual TeamMember TeamMember { get; set; }
        public virtual ICollection<TeamManagement> TeamManagements { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        [NotMapped]
        public virtual ICollection<User> Users { get; set; }
        [NotMapped]
        [DisplayName("Please Select Players To Add In Your Team ")]
        public string tm { get; set; }


    }
}
