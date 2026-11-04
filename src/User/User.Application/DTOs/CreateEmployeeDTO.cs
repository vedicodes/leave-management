using User.Domain.Enums;

namespace User.Application.DTOs;

/// <summary>
/// DTO for creating a new employee.
/// </summary>
/// <param name="Firstname">The first name of the employee.</param>
/// <param name="Lastname">The last name of the employee.</param>
/// <param name="Email">The email address of the employee.</param>
/// <param name="Password">The password for the employee's account. The password hash will be created and saved securely.</param>
/// <param name="Role">The role of the employee.</param>
/// <param name="ManagerId">The ID of the manager, if applicable.</param>
public record CreateEmployeeDTO(string Firstname, string Lastname, string Email, string Password, UserRole Role, Guid? ManagerId);