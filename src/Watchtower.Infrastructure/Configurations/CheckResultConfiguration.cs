using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchtower.Domain.Entities;

namespace Watchtower.Infrastructure.Persistence.Configurations;

public class CheckResultConfiguration : IEntityTypeConfiguration<CheckResult>
{
    public void Configure(EntityTypeBuilder<CheckResult> builder)
    {
        builder.ToTable("CheckResults");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.HasOne<MonitoredSite>()
               .WithMany()
               .HasForeignKey(x => x.MonitoredSiteId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.MonitoredSiteId, x.CheckedAtUtc },
                         "IX_CheckResults_MonitoredSiteId_CheckedAtUtc");
    }
}