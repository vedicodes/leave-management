namespace User.Domain.Entities;

public sealed class Role
{
    private Role() // EF Core
    {
    }

    public int Id { get; set; }
    public string Name { get; set; }
}