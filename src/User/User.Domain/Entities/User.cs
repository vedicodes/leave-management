namespace User.Domain.Entities;

public sealed class User
{
    private User() // EF Core
    {
    }

    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}