using User.Domain.Entities;

namespace User.Application.Contracts;

public interface IEmployeeRepository
{
    Task<Employee?> GetByEmailAsync(string email);
    Task<Employee?> GetByIdAsync(Guid id);
    Task<Employee?> GetManagerByIdAsync(Guid id);
    Task<IReadOnlyCollection<Employee>> GetAssociatesAsync();
    Task<IReadOnlyCollection<Employee>> GetAssociatesByManagerIdAsync(Guid managerId);
    Task<bool> SaveAsync(Employee employee);
    Task<bool> DeleteAsync(Employee employee);
}