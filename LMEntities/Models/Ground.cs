using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMEntities.Models
{
   

    public partial class Ground : Entity
    {
        public Ground()
        {
            this.Schedules = new List<Schedule>();
        }

       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Directions { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
