using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LMEntities.Models;
namespace LMEntities.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.EmailId)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.AspNetUsersId)
               .IsRequired().HasMaxLength(255);

            this.Property(t => t.FirstName)
                .HasMaxLength(100);

            this.Property(t => t.LastName)
                .HasMaxLength(100);

            this.Property(t => t.Password)
                .HasMaxLength(10);

            this.Property(t => t.ProfilePhoto)
                .HasMaxLength(255);
            this.Property(t => t.PlaceofBirth)
                          .HasMaxLength(50);

            this.Property(t => t.SchoolName)
                .HasMaxLength(50);

            this.Property(t => t.Grade)
                .HasMaxLength(50);

            this.Property(t => t.BattingStyle)
                .HasMaxLength(50);

            this.Property(t => t.FavouriteShot)
                .HasMaxLength(50);

            this.Property(t => t.BowlingStyle)
                .HasMaxLength(50);

            this.Property(t => t.FavoriteCricketer)
                .HasMaxLength(50);

            this.Property(t => t.Likes)
                .HasMaxLength(1000);

            this.Property(t => t.Dislikes)
                .HasMaxLength(1000);

            this.Property(t => t.FavouriteFood)
                .HasMaxLength(50);

            this.Property(t => t.FavouriteMovie)
                .HasMaxLength(50);

            this.Property(t => t.Ambition)
                .HasMaxLength(50);

            this.Property(t => t.Hobbies)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AspNetUsersId).HasColumnName("AspNetUsersId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.UserTypeId).HasColumnName("UserTypeId");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.GenderId).HasColumnName("GenderId");
            this.Property(t => t.ProfilePhoto).HasColumnName("ProfilePhoto");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.SkillSpecialityId).HasColumnName("SkillSpecialityId");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.PlaceofBirth).HasColumnName("PlaceofBirth");
            this.Property(t => t.LivedInUSAsince).HasColumnName("LivedInUSAsince");
            this.Property(t => t.SchoolName).HasColumnName("SchoolName");
            this.Property(t => t.Grade).HasColumnName("Grade");
            this.Property(t => t.BattingStyle).HasColumnName("BattingStyle");
            this.Property(t => t.FavouriteShot).HasColumnName("FavouriteShot");
            this.Property(t => t.BowlingStyle).HasColumnName("BowlingStyle");
            this.Property(t => t.FavoriteCricketer).HasColumnName("FavoriteCricketer");
            this.Property(t => t.Likes).HasColumnName("Likes");
            this.Property(t => t.Dislikes).HasColumnName("Dislikes");
            this.Property(t => t.FavouriteFood).HasColumnName("FavouriteFood");
            this.Property(t => t.FavouriteMovie).HasColumnName("FavouriteMovie");
            this.Property(t => t.Ambition).HasColumnName("Ambition");
            this.Property(t => t.Hobbies).HasColumnName("Hobbies");
         
            // Relationships
            this.HasOptional(t => t.Gender)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.GenderId);

            this.HasRequired(t => t.Organization)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.OrganizationId);
            
            this.HasOptional(t => t.UserType)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.UserTypeId);

        }
    }
}
