using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class AspNetUsersMap : EntityTypeConfiguration<AspNetUser>
    {
        public AspNetUsersMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                 .HasMaxLength(128);


        

            // Table & Column Mappings
            this.ToTable("AspNetUser");
            this.Property(t => t.Id).HasColumnName("Id");

        }
    }
}
