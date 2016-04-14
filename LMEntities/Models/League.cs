using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class League :Entity
    {
        public League()
        {
            this.Seasons = new List<Season>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
    }
}
