namespace User.Domain.Entities;

public sealed class UserRole
{
    private UserRole() //EF Core
    {
    }

    public Guid UserId { get; set; }
    public User User { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}