using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class EventMedia
    {
        public EventMedia()
        {
            this.MediaComments = new List<MediaComment>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string MediaPath { get; set; }
        public int MediaTypeId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual Event Event { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<MediaComment> MediaComments { get; set; }
    }
}
