using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            this.Property(t => t.ContactPhoneNumber1)
                .HasMaxLength(20);

            this.Property(t => t.ContactPhoneNumber2)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Event");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.HostId).HasColumnName("HostId");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.HomeTeamId).HasColumnName("HomeTeamId");
            this.Property(t => t.VisitorTeamId).HasColumnName("VisitorTeamId");
            this.Property(t => t.ContactPhoneNumber1).HasColumnName("ContactPhoneNumber1");
            this.Property(t => t.ContactPhoneNumber2).HasColumnName("ContactPhoneNumber2");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");

            // Relationships
            this.HasRequired(t => t.EventType)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.TypeId);
            this.HasOptional(t => t.Organization)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.Team)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.HomeTeamId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.CreatedBy);
            this.HasRequired(t => t.User1)
                .WithMany(t => t.Events1)
                .HasForeignKey(d => d.HostId);
            this.HasOptional(t => t.User2)
                .WithMany(t => t.Events2)
                .HasForeignKey(d => d.ModifiedBy);
            this.HasOptional(t => t.Team1)
                .WithMany(t => t.Events1)
                .HasForeignKey(d => d.VisitorTeamId);

        }
    }
}
