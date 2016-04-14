using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace LMEntities.Models
{
    public partial class Season : Entity
    {
        public Season()
        {
            this.Schedules = new List<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public int OrganizationId { get; set; }
        public virtual League League { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
