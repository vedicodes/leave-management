using User.Application.DTOs;

namespace User.Application.Services;

public interface IEmployeeService
{
    Task<TeamDTO?> GetTeamByManagerIdAsync(Guid managerId);
    Task<Guid> CreateEmployeeAsync(CreateEmployeeDTO user);
    Task<bool> UpdateEmployeeNameAsync(UpdateEmployeeDTO user);
    Task<bool> UpdateEmployeePasswordAsync(UpdateEmployeeDTO user);
    Task<bool> UpdateEmployeeManagerAsync(UpdateEmployeeDTO user);
    Task<bool> DeleteEmployeeAsync(Guid id);
}