using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class EventAddressMap : EntityTypeConfiguration<EventAddress>
    {
        public EventAddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Street1)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Street2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(50);

            this.Property(t => t.ZipCd)
                .HasMaxLength(50);

            this.Property(t => t.LandMark)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("EventAddress");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.Street1).HasColumnName("Street1");
            this.Property(t => t.Street2).HasColumnName("Street2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.ZipCd).HasColumnName("ZipCd");
            this.Property(t => t.LandMark).HasColumnName("LandMark");

            // Relationships
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventAddresses)
                .HasForeignKey(d => d.EventId);
            this.HasOptional(t => t.Organization)
                .WithMany(t => t.EventAddresses)
                .HasForeignKey(d => d.OrganizationId);

        }
    }
}
