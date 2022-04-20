using FootballWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballWebApp.Context.EfConfiguration
{
    public class ClubEntityEfConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
           // builder.ToTable("Clubs");
            builder.Property(a => a.ClubName).IsRequired().HasColumnType("Varchar(20)");
            builder.HasIndex(a => a.ClubName).IsUnique();
            builder.HasKey("Id");
            builder.HasMany(a => a.clubSponsors)
            .WithOne(a => a.Club)
            .HasForeignKey(a => a.ClubId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Property(a => a.ClubRegistrationNumber).IsRequired().HasColumnType("Varchar(20)");
            builder.HasIndex(a => a.ClubRegistrationNumber).IsUnique();
            builder.HasIndex(a => a.StadiumName).IsUnique();
            builder.Property(a => a.StadiumName).IsRequired().HasColumnType("Varchar(20)");
            builder.HasIndex(a => a.ClubNickName).IsUnique();
            builder.Property(a => a.ClubNickName).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(a => a.ClubNumberOfTrophies).IsRequired().HasColumnType("int(20)");
            builder.Property(a => a.ClubBiggestRival).IsRequired().HasColumnType("varchar(40)");
            builder.HasMany(a => a.players)
            .WithOne(a => a.Club)
            .HasForeignKey(a => a.ClubId)
            .OnDelete(DeleteBehavior.Restrict);



        }
    }
}