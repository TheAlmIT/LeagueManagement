using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;
namespace LMEntities.Models
{
    public partial class TeamTitle : Entity
    {
        public TeamTitle()
        {
            this.TeamManagements = new List<TeamManagement>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual ICollection<TeamManagement> TeamManagements { get; set; }
    }
}
