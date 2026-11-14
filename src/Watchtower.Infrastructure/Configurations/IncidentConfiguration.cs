using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchtower.Domain.Entities;

namespace Watchtower.Infrastructure.Persistence.Configurations;

public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> builder)
    {
        builder.ToTable("Incidents");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.RowVersion).IsRowVersion();

        builder.HasOne<MonitoredSite>()
               .WithMany()
               .HasForeignKey(x => x.MonitoredSiteId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.MonitoredSiteId, "IX_Incidents_MonitoredSiteId");

        builder.HasIndex(x => x.MonitoredSiteId, "UX_Incidents_OneOpenPerSite")
       .IsUnique()
       .HasFilter("\"ResolvedAtUtc\" IS NULL");
    }
}