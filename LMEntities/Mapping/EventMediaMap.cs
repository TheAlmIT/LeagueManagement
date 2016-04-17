using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class EventMediaMap : EntityTypeConfiguration<EventMedia>
    {
        public EventMediaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MediaPath)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("EventMedia");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MediaPath).HasColumnName("MediaPath");
            this.Property(t => t.MediaTypeId).HasColumnName("MediaTypeId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventMedias)
                .HasForeignKey(d => d.EventId);
            this.HasRequired(t => t.MediaType)
                .WithMany(t => t.EventMedias)
                .HasForeignKey(d => d.MediaTypeId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.EventMedias)
                .HasForeignKey(d => d.OrganizationId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.EventMedias)
                .HasForeignKey(d => d.CreatedBy);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.EventMedias1)
                .HasForeignKey(d => d.ModifiedBy);

        }
    }
}
