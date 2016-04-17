using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class FacilityBookingMap : EntityTypeConfiguration<FacilityBooking>
    {
        public FacilityBookingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("FacilityBookings");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.FacilityId).HasColumnName("FacilityId");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.StatusId).HasColumnName("StatusId");

            // Relationships
            this.HasRequired(t => t.Facility)
                .WithMany(t => t.FacilityBookings)
                .HasForeignKey(d => d.FacilityId);
            this.HasRequired(t => t.FacilityBookingStatu)
                .WithMany(t => t.FacilityBookings)
                .HasForeignKey(d => d.StatusId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.FacilityBookings)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.FacilityBookings)
                .HasForeignKey(d => d.ModifiedBy);
            this.HasRequired(t => t.User1)
                .WithMany(t => t.FacilityBookings1)
                .HasForeignKey(d => d.CreatedBy);

        }
    }
}
