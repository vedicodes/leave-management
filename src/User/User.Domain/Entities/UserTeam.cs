namespace User.Domain.Entities;

public sealed class UserTeam
{
    private UserTeam() // EF Core
    {
    }

    public Guid ManagerId { get; set; }
    public User Manager { get; set; }
    public Guid EmployeeId { get; set; }
    public User Employee { get; set; }
}