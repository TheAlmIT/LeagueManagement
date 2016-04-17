using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMEntities.Models
{
    public partial class TeamMember :Entity
    {
        public TeamMember()
        {
            this.MatchResults = new List<MatchResult>();
            this.TeamManagements = new List<TeamManagement>();
        }
      
        public int ID { get; set; }
        [DisplayName("Organization Name")]
        public int OrganizationId { get; set; }
        [DisplayName("Team Name")]
        public int TeamId { get; set; }
        [DisplayName("User Name")]
        public int UserId { get; set; }
        public string Name { get; set; }
       
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual ICollection<MatchResult> MatchResults { get; set; }
        public virtual Team Team { get; set; }
        public virtual User  User { get; set; }
        public virtual ICollection<TeamManagement> TeamManagements { get; set; }
    }
}
