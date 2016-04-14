using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
     public class GroundMap : EntityTypeConfiguration<Ground>
        {
            public GroundMap()
            {
                // Primary Key
                this.HasKey(t => t.Id);

            //// Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("Ground");
                this.Property(t => t.Id).HasColumnName("Id");
                this.Property(t => t.Name).HasColumnName("Name");
                this.Property(t => t.Address).HasColumnName("Address");
                this.Property(t => t.Directions).HasColumnName("Directions");

            }
        }
    }


