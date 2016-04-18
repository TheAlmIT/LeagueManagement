using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class TeamMemberMap : EntityTypeConfiguration<TeamMember>
    {
        public TeamMemberMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            //this.Property(t => t.NickName)
            //    .IsRequired()
            //    .HasMaxLength(50);

          

            // Table & Column Mappings
            this.ToTable("TeamMember");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");
           
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.Team)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(d => d.TeamId);

            this.HasRequired(t => t.User)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(d => d.UserId);

        }
    }
}
