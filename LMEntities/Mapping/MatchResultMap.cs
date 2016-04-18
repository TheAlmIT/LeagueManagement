using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class MatchResultMap : EntityTypeConfiguration<MatchResult>
    {
        public MatchResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Summary)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("MatchResult");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ScheduleId).HasColumnName("ScheduleId");
            this.Property(t => t.WinningTeamId).HasColumnName("WinningTeamId");
            this.Property(t => t.LosingTeamId).HasColumnName("LosingTeamId");
            this.Property(t => t.WinningTeamPoints).HasColumnName("WinningTeamPoints");
            this.Property(t => t.LosingTeamPoints).HasColumnName("LosingTeamPoints");
            this.Property(t => t.WinningTeamScore).HasColumnName("WinningTeamScore");
            this.Property(t => t.LosingTeamScore).HasColumnName("LosingTeamScore");
            this.Property(t => t.WinningTeamWkts).HasColumnName("WinningTeamWkts");
            this.Property(t => t.LosingTeamWkts).HasColumnName("LosingTeamWkts");
            this.Property(t => t.WinningTeamOvers).HasColumnName("WinningTeamOvers");
            this.Property(t => t.LosingTeamOvers).HasColumnName("LosingTeamOvers");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.MVPlayerId).HasColumnName("MVPlayerId");
            this.Property(t => t.TossWinningTeamId).HasColumnName("TossWinningTeamId");
            this.Property(t => t.FirstBattingTeamId).HasColumnName("FirstBattingTeamId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.MatchResults)
                .HasForeignKey(d => d.CreatedBy);
            this.HasRequired(t => t.Team)
                .WithMany(t => t.MatchResults)
                .HasForeignKey(d => d.FirstBattingTeamId);
            this.HasRequired(t => t.Team1)
                .WithMany(t => t.MatchResults1)
                .HasForeignKey(d => d.LosingTeamId);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.MatchResults1)
                .HasForeignKey(d => d.ModifiedBy);
            this.HasRequired(t => t.Schedule)
                .WithMany(t => t.MatchResults)
                .HasForeignKey(d => d.ScheduleId);
            this.HasRequired(t => t.TeamMember)
                .WithMany(t => t.MatchResults)
                .HasForeignKey(d => d.MVPlayerId);
            this.HasRequired(t => t.Team2)
                .WithMany(t => t.MatchResults2)
                .HasForeignKey(d => d.TossWinningTeamId);
            this.HasRequired(t => t.Team3)
                .WithMany(t => t.MatchResults3)
                .HasForeignKey(d => d.WinningTeamId);

        }
    }
}
