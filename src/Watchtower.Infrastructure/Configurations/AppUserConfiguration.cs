using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchtower.Domain.Entities;

namespace Watchtower.Infrastructure.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Email).IsRequired().HasMaxLength(320);
            builder.Property(x => x.PasswordHash).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
