using User.Domain.Enums;

namespace User.Application.DTOs;

public record EmployeeDTO(Guid Id, string Firstname, string Lastname, string Email, UserRole Role, Guid? ManagerId);