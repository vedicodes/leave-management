using User.Application.DTOs;

namespace User.Application.Services;

public interface IEmployeeService
{
    Task<TeamDTO?> GetTeamByManagerIdAsync(Guid managerId);
    Task<Guid> CreateEmployeeAsync(CreateEmployeeDTO user);
    Task<bool> UpdateEmployeeNameAsync(UpdateEmployeeNameDTO user);
    Task<bool> UpdateEmployeePasswordAsync(UpdateEmployeePasswordDTO user);
    Task<bool> UpdateEmployeeManagerAsync(UpdateEmployeeManagerDTO user);
    Task<bool> DeleteEmployeeAsync(Guid id);
}