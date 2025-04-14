using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(e => e.Id)
            .IsRequired();
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasMany(o => o.Projects)
            .WithOne(p => p.Organization)
            .HasForeignKey(p => p.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Many-to-Many Organization ↔ Admins (Users)
        builder.HasMany(o => o.Admins)
            .WithMany() // you can define a navigation property in User if needed
            .UsingEntity(j => j.ToTable("OrganizationAdmins"));

        builder.Property(e => e.CreatedAt)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .IsRequired();
    }
}