using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchtower.Domain.Entities;

namespace Watchtower.Infrastructure.Persistence.Configurations;

public class MonitoredSiteConfiguration : IEntityTypeConfiguration<MonitoredSite>
{
    public void Configure(EntityTypeBuilder<MonitoredSite> builder)
    {
        builder.ToTable("MonitoredSites");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Url).IsRequired().HasMaxLength(2048);

        builder.HasOne<AppUser>()
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}