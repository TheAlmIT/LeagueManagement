using System;
using System.Collections.Generic;
using System.ComponentModel;
using Repository.Pattern.Ef6;

namespace LMEntities.Models
{
    public sealed class SkillSpeciality :Entity
    {
        public SkillSpeciality()
        {
            TeamMembers = new List<User>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        [DisplayName("Playing Role")]
        public string Name { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public ICollection<User> TeamMembers { get; set; }
    }
}
