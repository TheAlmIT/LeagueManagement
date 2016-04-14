using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class NotificationType
    {
        public NotificationType()
        {
            this.Notifications = new List<Notification>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
