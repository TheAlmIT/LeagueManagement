using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class EventCommentMap : EntityTypeConfiguration<EventComment>
    {
        public EventCommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.EventComments)
                .HasMaxLength(500);

            this.Property(t => t.MediaPath)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("EventComment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.EventComments).HasColumnName("EventComments");
            this.Property(t => t.MediaPath).HasColumnName("MediaPath");
            this.Property(t => t.ParentCommentId).HasColumnName("ParentCommentId");
            this.Property(t => t.CommentedBy).HasColumnName("CommentedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventComments)
                .HasForeignKey(d => d.EventId);
            this.HasOptional(t => t.EventComment2)
                .WithMany(t => t.EventComment1)
                .HasForeignKey(d => d.ParentCommentId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.EventComments)
                .HasForeignKey(d => d.OrganizationId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.EventComments)
                .HasForeignKey(d => d.CommentedBy);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.EventComments1)
                .HasForeignKey(d => d.ModifiedBy);

        }
    }
}
