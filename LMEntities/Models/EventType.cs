using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class EventType
    {
        public EventType()
        {
            this.Events = new List<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
