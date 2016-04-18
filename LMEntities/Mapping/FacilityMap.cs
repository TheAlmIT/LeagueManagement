using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class FacilityMap : EntityTypeConfiguration<Facility>
    {
        public FacilityMap()
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
            this.ToTable("Facility");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.FacilityBookingUnitTypeId).HasColumnName("FacilityBookingUnitTypeId");
            this.Property(t => t.UnitRate).HasColumnName("UnitRate");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");

            // Relationships
            this.HasRequired(t => t.FacilityBookingUnitType)
                .WithMany(t => t.Facilities)
                .HasForeignKey(d => d.FacilityBookingUnitTypeId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.Facilities)
                .HasForeignKey(d => d.OrganizationId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Facilities)
                .HasForeignKey(d => d.CreatedBy);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.Facilities1)
                .HasForeignKey(d => d.ModifiedBy);

        }
    }
}
