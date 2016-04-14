using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class UserType
    {
        public UserType()
        {
            this.Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
