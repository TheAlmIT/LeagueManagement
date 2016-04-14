using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class MediaComment
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public int OrganizationId { get; set; }
        public string Comments { get; set; }
        public Nullable<int> CommentedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public virtual EventMedia EventMedia { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
