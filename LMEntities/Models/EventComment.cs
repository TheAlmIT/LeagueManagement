using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class EventComment
    {
        public EventComment()
        {
            this.EventComment1 = new List<EventComment>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public int OrganizationId { get; set; }
        public string EventComments { get; set; }
        public string MediaPath { get; set; }
        public Nullable<int> ParentCommentId { get; set; }
        public int CommentedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual Event Event { get; set; }
        public virtual ICollection<EventComment> EventComment1 { get; set; }
        public virtual EventComment EventComment2 { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
