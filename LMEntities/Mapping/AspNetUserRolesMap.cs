using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;

namespace LMEntities.Models.Mapping
{
    public class AspNetUserRolesMap : EntityTypeConfiguration<AspNetUserRoles>
    {
        public AspNetUserRolesMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.RoleId)
                .IsRequired()
                 .HasMaxLength(128);


            this.Property(t => t.UserId)
                 .IsRequired()
                .HasMaxLength(128);


            // Table & Column Mappings
            this.ToTable("AspNetUserRoles");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");


            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.AspNetUserRoles)
                .HasForeignKey(d => d.UserId);

            this.HasRequired(t => t.AspNetRole)
                .WithMany(t => t.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
