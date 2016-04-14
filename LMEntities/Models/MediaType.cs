using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class MediaType
    {
        public MediaType()
        {
            this.EventMedias = new List<EventMedia>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EventMedia> EventMedias { get; set; }
    }
}
