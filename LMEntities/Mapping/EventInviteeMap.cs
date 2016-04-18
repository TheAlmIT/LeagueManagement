using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class EventInviteeMap : EntityTypeConfiguration<EventInvitee>
    {
        public EventInviteeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EventInvitee");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.NotificationSentOn).HasColumnName("NotificationSentOn");
            this.Property(t => t.RSVPId).HasColumnName("RSVPId");
            this.Property(t => t.RSVPDateTime).HasColumnName("RSVPDateTime");

            // Relationships
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventInvitees)
                .HasForeignKey(d => d.EventId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.EventInvitees)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.RSVPMaster)
                .WithMany(t => t.EventInvitees)
                .HasForeignKey(d => d.RSVPId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.EventInvitees)
                .HasForeignKey(d => d.UserId);

        }
    }
}
