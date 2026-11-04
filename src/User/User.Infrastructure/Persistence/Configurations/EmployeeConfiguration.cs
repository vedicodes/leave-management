namespace User.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Entities;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Firstname).IsRequired().HasMaxLength(100);
        entity.Property(e => e.Lastname).IsRequired().HasMaxLength(100);
        entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
        entity.Property(e => e.PasswordHash).IsRequired();
        entity.Property(e => e.Role)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();
        entity.Property(e => e.ManagerId);

        entity.HasIndex(e => e.Email).IsUnique();

        entity.HasOne(e => e.Manager)
            .WithMany(e => e.Associates)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}