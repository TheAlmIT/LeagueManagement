using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int NotificationTypeId { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string CCAddress { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public System.DateTime SentOn { get; set; }
        public int StatusId { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public virtual NotificationStatu NotificationStatu { get; set; }
        public virtual NotificationType NotificationType { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
