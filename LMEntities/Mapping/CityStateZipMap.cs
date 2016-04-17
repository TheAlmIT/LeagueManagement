using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class CityStateZipMap : EntityTypeConfiguration<CityStateZip>
    {
        public CityStateZipMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CityStateZip");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zipcode).HasColumnName("Zipcode");
        }
    }
}
