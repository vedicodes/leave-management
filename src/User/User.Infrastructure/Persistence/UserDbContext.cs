namespace User.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    // Define DbSets for your entities here
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Scans the compiled User.Infrastructure assembly (.dll) using reflection to find all classes
        // that implement IEntityTypeConfiguration<TEntity> (e.g., EmployeeConfiguration) and automatically
        // invokes their Configure() method. New entity configurations added to this project are picked up
        // automatically without modifying UserDbContext.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
}