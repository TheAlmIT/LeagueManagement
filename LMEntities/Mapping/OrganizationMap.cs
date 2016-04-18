using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class OrganizationMap : EntityTypeConfiguration<Organization>
    {
        public OrganizationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(50);

            this.Property(t => t.ZipCode)
                .HasMaxLength(12);

            this.Property(t => t.WorkTelephone1)
                .HasMaxLength(50);

            this.Property(t => t.EmailId)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            this.Property(t => t.LogoLocation)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Organization");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
            this.Property(t => t.WorkTelephone1).HasColumnName("WorkTelephone1");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.LogoLocation).HasColumnName("LogoLocation");
        }
    }
}
