using FootballWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballWebApp.Context.EfConfiguration
{
    public class PlayerEntityEfConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
              builder.ToTable("Players");
            builder.Property(a => a.ClubId).IsRequired();
            builder.HasIndex(a => a.Email).IsUnique();
            builder.HasKey("Id");
             builder.Property(a => a.Email).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(a => a.FirstName).IsRequired().HasColumnType("Varchar(20)");
            builder.HasIndex(a => a.PlayerPhoto).IsUnique();
            builder.Property(a => a.Nationality).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(a => a.PlayerPhoto).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(a => a.PlayingPosition).IsRequired().HasColumnType("varchar(20)");
            builder.Property(a => a.StrongFoot).IsRequired().HasColumnType("varchar(20)");
            builder.Property(a => a.JerseyNumber).IsRequired().HasColumnType("int(20)");
            builder.Property(a => a.WeeklySalary).IsRequired().HasColumnType("decimal(50)");
            builder.Property(a => a.DateOfBirth).IsRequired().HasColumnType("DateTime(6)");
        }
    }
}