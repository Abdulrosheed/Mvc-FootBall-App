using FootballWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballWebApp.Context.EfConfiguration
{
    public class SponsorerEntityEfConfiguration : IEntityTypeConfiguration<Sponsorer>
    {
        public void Configure(EntityTypeBuilder<Sponsorer> builder)
        {
            builder.ToTable("Sponsorer");
            builder.HasKey("Id");
            builder.HasMany(a => a.clubSponsors)
            .WithOne(a => a.Sponsorer)
            .HasForeignKey(a => a.SponsorerId)
            .OnDelete(DeleteBehavior.Restrict);
            builder.Property(a => a.Name).IsRequired().HasColumnType("varchar(30)");
            builder.HasIndex(a => a.Name).IsUnique();
             builder.Property(a => a.RegistrationNumber).IsRequired().HasColumnType("varchar(40)");
            builder.HasIndex(a => a.RegistrationNumber).IsUnique();
             builder.Property(a => a.NetWorth).IsRequired().HasColumnType("decimal(30)");
             builder.Property(a => a.SponsorerNumberOfCompanies).IsRequired().HasColumnType("varchar(30)");
            
            

        }
    }
}