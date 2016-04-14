using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class TeamManagement
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int TeamId { get; set; }
        public int TitleId { get; set; }
        public int TeamMemberId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual Team Team { get; set; }
        public virtual TeamMember TeamMember { get; set; }
        public virtual TeamTitle TeamTitle { get; set; }
    }
}
