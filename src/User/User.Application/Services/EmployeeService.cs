using User.Application.Contracts;
using User.Application.DTOs;
using User.Domain.Entities;

namespace User.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPasswordHasher _passwordHasher;

    public EmployeeService(IEmployeeRepository employeeRepository, IPasswordHasher passwordHasher)
    {
        _employeeRepository = employeeRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<TeamDTO?> GetTeamByManagerIdAsync(Guid managerId)
    {
        var manager = await _employeeRepository.GetManagerByIdAsync(managerId);
        if (manager == null)
            throw new ArgumentException("Manager not found");

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
        if (employee == null)
            throw new ArgumentException("Employee not found");

        employee.ChangeName(user.Firstname, user.Lastname);
        return await _employeeRepository.SaveAsync(employee);
    }

    public async Task<bool> UpdateEmployeePasswordAsync(UpdateEmployeePasswordDTO user)
    {
        var employee = await _employeeRepository.GetByIdAsync(user.Id);
        if (employee == null)
            throw new ArgumentException("Employee not found");

        var passwordHash = _passwordHasher.HashPassword(user.Password);
        employee.ChangePasswordHash(passwordHash);
        return await _employeeRepository.SaveAsync(employee);
    }

    public async Task<bool> UpdateEmployeeManagerAsync(UpdateEmployeeManagerDTO user)
    {
        var employee = await _employeeRepository.GetByIdAsync(user.Id);
        if (employee == null)
            throw new ArgumentException("Employee not found");
        
        employee.ChangeManager(user.ManagerId);
        return await _employeeRepository.SaveAsync(employee);
    }

    public async Task<bool> DeleteEmployeeAsync(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null)
            throw new ArgumentException("Employee not found");
        
        return await _employeeRepository.DeleteAsync(employee);
    }
}