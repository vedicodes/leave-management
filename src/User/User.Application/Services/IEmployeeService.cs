using User.Application.DTOs;

namespace User.Application.Services;

public interface IEmployeeService
{
    Task<TeamDTO> GetTeamByManagerIdAsync(Guid managerId);
    Task<Guid> CreateEmployeeAsync(CreateEmployeeDTO user);
    Task<bool> UpdateEmployeeAsync(UpdateEmployeeDTO user);
}