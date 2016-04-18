using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NickName)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(1000);

            this.Property(t => t.PhotoUrl)
                .HasMaxLength(255);


            // Table & Column Mappings
            this.ToTable("Team");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PhotoUrl).HasColumnName("PhotoUrl");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.Teams)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Teams)
                .HasForeignKey(d => d.CreatedBy);



        }
    }
}
