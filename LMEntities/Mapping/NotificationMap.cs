using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class NotificationMap : EntityTypeConfiguration<Notification>
    {
        public NotificationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FromAddress)
                .IsRequired();

            this.Property(t => t.ToAddress)
                .IsRequired();

            this.Property(t => t.Subject)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Notifications");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.NotificationTypeId).HasColumnName("NotificationTypeId");
            this.Property(t => t.FromAddress).HasColumnName("FromAddress");
            this.Property(t => t.ToAddress).HasColumnName("ToAddress");
            this.Property(t => t.CCAddress).HasColumnName("CCAddress");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.MessageBody).HasColumnName("MessageBody");
            this.Property(t => t.SentOn).HasColumnName("SentOn");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.NotificationStatu)
                .WithMany(t => t.Notifications)
                .HasForeignKey(d => d.StatusId);
            this.HasRequired(t => t.NotificationType)
                .WithMany(t => t.Notifications)
                .HasForeignKey(d => d.NotificationTypeId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.Notifications)
                .HasForeignKey(d => d.OrganizationId);

        }
    }
}
