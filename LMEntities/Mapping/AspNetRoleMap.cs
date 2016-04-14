using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class AspNetRoleMap : EntityTypeConfiguration<AspNetRole>
    {
        public AspNetRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                 .HasMaxLength(128);


            this.Property(t => t.Name)
                .HasMaxLength(256);

           
            // Table & Column Mappings
            this.ToTable("AspNetRole");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            
        }
    }
}
