using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEntities.Models
{
    public partial class AspNetUserRoles : Entity
    {
       
        public string UserId { get; set; }
       
        public string RoleId { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<AspNetRole> AspNetUsersRoles { get; set; }
        
    }
}
