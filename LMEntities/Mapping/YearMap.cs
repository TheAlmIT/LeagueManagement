using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
   
    public class YearMap : EntityTypeConfiguration<Year>
    {
        public YearMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Year");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.YearNumber).HasColumnName("YearNumber");
        }
    }
}
