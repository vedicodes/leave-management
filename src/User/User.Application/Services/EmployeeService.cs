using User.Application.DTOs;

namespace User.Application.Services;

public class EmployeeService : IEmployeeService
{
    public Task<Guid> CreateEmployeeAsync(CreateEmployeeDTO user)
    {
        throw new NotImplementedException();
    }

    public Task<TeamDTO> GetTeamByManagerIdAsync(Guid managerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateEmployeeAsync(UpdateEmployeeDTO user)
    {
        throw new NotImplementedException();
    }
}