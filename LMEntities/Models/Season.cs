using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;
using System.ComponentModel;

namespace LMEntities.Models
{
    public partial class Season : Entity
    {
        public Season()
        {
            this.Schedules = new List<Schedule>();
        }

        public int Id { get; set; }
        [DisplayName("Season Name")]
        public string Name { get; set; }
        [DisplayName("League Name")]
        public int LeagueId { get; set; }
        [DisplayName("Organization Name")]
        public int OrganizationId { get; set; }
        public virtual League League { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
