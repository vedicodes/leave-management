using User.Domain.Enums;

namespace User.Domain.Entities;

public sealed class Employee
{
    private Employee() // EF Core
    {
    }

    private Employee(Guid id, string firstname, string lastname, string email, string passwordHash, UserRole role, Guid? managerId)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        ManagerId = managerId;
    }

    public Guid Id { get; private set; }
    public string Firstname { get; private set; } = null!;
    public string Lastname { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserRole Role { get; private set; }
    public Guid? ManagerId { get; private set; }
    public Employee? Manager { get; private set; }
    private readonly List<Employee> _associates = [];
    public IReadOnlyCollection<Employee> Associates => _associates.AsReadOnly();

    public static Employee Create(string firstname, string lastname, string email, string passwordHash, UserRole role, Guid? managerId)
    {
        if (string.IsNullOrWhiteSpace(firstname))
            throw new ArgumentException("Firstname cannot be empty.", nameof(firstname));
        if (string.IsNullOrWhiteSpace(lastname))
            throw new ArgumentException("Lastname cannot be empty.", nameof(lastname));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.", nameof(email));
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("PasswordHash cannot be empty.", nameof(passwordHash));
        if (role == UserRole.Associate && managerId == null)
            throw new ArgumentException("User must have a manager.", nameof(managerId));
        if (role == UserRole.Associate && managerId == Guid.Empty)
            throw new ArgumentException("User must have a valid manager.", nameof(managerId));
        if (role == UserRole.Manager && managerId != null)
            throw new ArgumentException("Manager cannot have a manager.", nameof(managerId));

        return new Employee(Guid.CreateVersion7(), firstname.Trim(), lastname.Trim(), email.Trim(), passwordHash, role, managerId);
    }

    public void ChangePasswordHash(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash))
            throw new ArgumentException("New password hash cannot be empty.", nameof(newPasswordHash));

        PasswordHash = newPasswordHash;
    }

    public void ChangeManager(Guid? newManagerId)
    {
        if (Role == UserRole.Manager && newManagerId != null)
            throw new ArgumentException("Manager cannot have a manager.", nameof(newManagerId));
        if (Role == UserRole.Associate && newManagerId == null)
            throw new ArgumentException("User must have a manager.", nameof(newManagerId));
        if (Role == UserRole.Associate && newManagerId == ManagerId)
            throw new ArgumentException("New manager must be different from the current manager.", nameof(newManagerId));
        if (Role == UserRole.Associate && newManagerId == Guid.Empty)
            throw new ArgumentException("New manager cannot be empty.", nameof(newManagerId));
        if (Role == UserRole.Associate && Id == newManagerId)
            throw new ArgumentException("User cannot be their own manager.", nameof(newManagerId));

        ManagerId = newManagerId;
    }

    public void ChangeName(string firstname, string lastname)
    {
        if (string.IsNullOrWhiteSpace(firstname))
            throw new ArgumentException("Firstname cannot be empty.", nameof(firstname));
        if (string.IsNullOrWhiteSpace(lastname))
            throw new ArgumentException("Lastname cannot be empty.", nameof(lastname));
        if (Firstname == firstname.Trim() && Lastname == lastname.Trim())
            throw new ArgumentException("New name must be different from the current name.", nameof(firstname));

        Firstname = firstname.Trim();
        Lastname = lastname.Trim();
    }
}