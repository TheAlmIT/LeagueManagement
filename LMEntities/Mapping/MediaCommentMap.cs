using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class MediaCommentMap : EntityTypeConfiguration<MediaComment>
    {
        public MediaCommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Comments)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("MediaComment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaId).HasColumnName("MediaId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.CommentedBy).HasColumnName("CommentedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.EventMedia)
                .WithMany(t => t.MediaComments)
                .HasForeignKey(d => d.MediaId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.MediaComments)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.MediaComments)
                .HasForeignKey(d => d.CommentedBy);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.MediaComments1)
                .HasForeignKey(d => d.ModifiedBy);

        }
    }
}
