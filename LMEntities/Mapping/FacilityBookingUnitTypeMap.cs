using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class FacilityBookingUnitTypeMap : EntityTypeConfiguration<FacilityBookingUnitType>
    {
        public FacilityBookingUnitTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FacilityBookingUnitType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");

            // Relationships
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.FacilityBookingUnitTypes)
                .HasForeignKey(d => d.OrganizationId);

        }
    }
}
