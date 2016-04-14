using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEntities.Models
{
    public partial class AspNetRole : Entity
    {
        //public AspNetRole()
        //{
        //    AspNetUsers = new HashSet<AspNetUser>();
        //}
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

       
        //public virtual ICollection<AspNetUser> AspNetUsers { get; set; }

        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }

    }
}
