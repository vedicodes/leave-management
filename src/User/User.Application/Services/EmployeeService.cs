using User.Application.Contracts;
using User.Application.DTOs;
using User.Domain.Entities;

namespace User.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<TeamDTO?> GetTeamByManagerIdAsync(Guid managerId)
    {
        var manager = await _employeeRepository.GetManagerByIdAsync(managerId);
        if (manager == null) return null;

        return new TeamDTO
        {
            Manager = new EmployeeDTO(manager.Id, manager.Firstname, manager.Lastname, manager.Email, manager.Role, null),
            Associates = manager.Associates.Select(associate => new EmployeeDTO(associate.Id, associate.Firstname, associate.Lastname, associate.Email, associate.Role, associate.ManagerId)).ToList().AsReadOnly()
        };
    }

    public async Task<Guid> CreateEmployeeAsync(CreateEmployeeDTO user)
    {
        var employee = Employee.Create(user.Firstname, user.Lastname, user.Email, user.Password, user.Role, user.ManagerId);
        await _employeeRepository.SaveAsync(employee);

        return employee.Id;
    }

    public async Task<bool> UpdateEmployeeNameAsync(UpdateEmployeeNameDTO user)
    {
        var employee = await _employeeRepository.GetByIdAsync(user.Id);
        if (employee == null) return false;

        employee.ChangeName(user.Firstname, user.Lastname);
        return await _employeeRepository.SaveAsync(employee);
    }

    public async Task<bool> UpdateEmployeePasswordAsync(UpdateEmployeePasswordDTO user)
    {
        var employee = await _employeeRepository.GetByIdAsync(user.Id);
        if (employee == null) return false;

        // Add Password Hasher Logic
        employee.ChangePasswordHash(user.Password);
        return await _employeeRepository.SaveAsync(employee);
    }

    public async Task<bool> UpdateEmployeeManagerAsync(UpdateEmployeeManagerDTO user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteEmployeeAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}