using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class ScheduleMap : EntityTypeConfiguration<Schedule>
    {
        public ScheduleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Schedule");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SeasonId).HasColumnName("SeasonId");
            this.Property(t => t.YearId).HasColumnName("YearId");
            this.Property(t => t.HomeTeamId).HasColumnName("HomeTeamId");
            this.Property(t => t.VisitorTeamId).HasColumnName("VisitorTeamId");
            this.Property(t => t.UmpireId).HasColumnName("UmpireId");
            this.Property(t => t.GroundId).HasColumnName("GroundId");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.ScheduleDate).HasColumnName("ScheduleDate");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.ModfiedBy).HasColumnName("ModfiedBy");

            // Relationships
            this.HasRequired(t => t.Season)
                .WithMany(t => t.Schedules)
                .HasForeignKey(d => d.SeasonId);
            //this.HasRequired(t => t.Year)
            //    .WithMany(t => t.Schedules)
            //    .HasForeignKey(d => d.YearId);

            this.HasRequired(t => t.Ground)
                .WithMany(t => t.Schedules)
                .HasForeignKey(d => d.GroundId);

            this.HasRequired(t => t.Umpire)
                .WithMany(t => t.Schedules)
                .HasForeignKey(d => d.UmpireId);

            this.HasRequired(t => t.Team)
               .WithMany(t => t.Schedules)
               .HasForeignKey(d => d.HomeTeamId);

            this.HasRequired(t => t.Team1)
               .WithMany(t => t.Schedules1)
               .HasForeignKey(d => d.VisitorTeamId);



        }
    }
}
