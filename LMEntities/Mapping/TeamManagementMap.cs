using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class TeamManagementMap : EntityTypeConfiguration<TeamManagement>
    {
        public TeamManagementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TeamManagement");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.TitleId).HasColumnName("TitleId");
            this.Property(t => t.TeamMemberId).HasColumnName("TeamMemberId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.Team)
                .WithMany(t => t.TeamManagements)
                .HasForeignKey(d => d.TeamId);
            this.HasRequired(t => t.TeamMember)
                .WithMany(t => t.TeamManagements)
                .HasForeignKey(d => d.TeamMemberId);
            this.HasRequired(t => t.TeamTitle)
                .WithMany(t => t.TeamManagements)
                .HasForeignKey(d => d.TitleId);

        }
    }
}
