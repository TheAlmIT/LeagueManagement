using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class SeasonMap : EntityTypeConfiguration<Season>
    {
        public SeasonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Season");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LeagueId).HasColumnName("LeagueId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");

            // Relationships
            this.HasRequired(t => t.League)
                .WithMany(t => t.Seasons)
                .HasForeignKey(d => d.LeagueId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.Seasons)
                .HasForeignKey(d => d.OrganizationId);

        }
    }
}
