using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class Year
    {
        public Year()
        {
            this.Schedules = new List<Schedule>();
        }

        public int Id { get; set; }
        public int YearNumber { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
