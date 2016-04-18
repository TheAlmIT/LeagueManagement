using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class FacilityCancellationMap : EntityTypeConfiguration<FacilityCancellation>
    {
        public FacilityCancellationMap()
        {
            // Primary Key
            this.HasKey(t => t.FacilityBookingId);

            // Properties
            this.Property(t => t.FacilityBookingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Reason)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("FacilityCancellations");
            this.Property(t => t.FacilityBookingId).HasColumnName("FacilityBookingId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.CanceledOn).HasColumnName("CanceledOn");
            this.Property(t => t.CanceledBy).HasColumnName("CanceledBy");
            this.Property(t => t.Reason).HasColumnName("Reason");

            // Relationships
            this.HasRequired(t => t.FacilityBooking)
                .WithOptional(t => t.FacilityCancellation);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.FacilityCancellations)
                .HasForeignKey(d => d.OrganizationId);

        }
    }
}
