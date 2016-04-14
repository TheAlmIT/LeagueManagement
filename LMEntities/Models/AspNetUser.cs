using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEntities.Models
{
    public partial class AspNetUser
    {

        //public AspNetUser()
        //{          
        //    AspNetRoles = new HashSet<AspNetRole>();
        //}
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
     
        //public virtual ICollection<AspNetRole> AspNetRoles { get; set; }

        public virtual ICollection<AspNetUserRoles> AspNetUsersRoles { get; set; }
    }
}
