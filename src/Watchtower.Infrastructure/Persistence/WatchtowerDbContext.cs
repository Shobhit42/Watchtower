using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Watchtower.Domain.Entities;

namespace Watchtower.Infrastructure.Persistence
{
    public class WatchtowerDbContext : DbContext
    {
        public WatchtowerDbContext(DbContextOptions<WatchtowerDbContext> options)
        : base(options) { }

        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<MonitoredSite> MonitoredSites => Set<MonitoredSite>();
        public DbSet<CheckResult> CheckResults => Set<CheckResult>();
        public DbSet<Incident> Incidents => Set<Incident>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WatchtowerDbContext).Assembly);
        }

    }
}
