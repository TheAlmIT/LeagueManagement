using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class AspNetUserRoleMap : EntityTypeConfiguration<AspNetUserRoles>
    {
        public AspNetUserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.UserId)
                .IsRequired()
                 .HasMaxLength(128);

            this.Property(t => t.RoleId)
                .IsRequired()
                 .HasMaxLength(128);





            // Table & Column Mappings
            this.ToTable("AspNetUserRoles");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");



            this.HasRequired(t => t.AspNetUser)
              .WithMany(t => t.AspNetUsersRoles)
              .HasForeignKey(d => d.UserId);
            //this.HasRequired(t => t.AspNetRole)
            //    .WithMany(t => t.AspNetUsersRoles)
            //    .HasForeignKey(d => d.RoleId);


        }
    }
}
