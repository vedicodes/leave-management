using User.Domain.Entities;

namespace User.Application.Contracts;

public interface IEmployeeRepository
{
    Task<Employee?> GetByEmailAsync(string email);
    Task<IReadOnlyCollection<Employee>> GetAssociatesAsync();
    Task<IReadOnlyCollection<Employee>> GetAssociatesByManagerIdAsync(Guid managerId);
}