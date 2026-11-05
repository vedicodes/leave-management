using User.Application.Contracts;

namespace User.Application.Services;

public class AuthService : IAuthService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthService(IEmployeeRepository employeeRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator)
    {
        _employeeRepository = employeeRepository;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> GetTokenAsync(string email, string password)
    {
        var employee = await _employeeRepository.GetByEmailAsync(email);
        if (employee == null)
            throw new ArgumentException("Employee not found", nameof(email));

        return !_passwordHasher.VerifyPassword(password, employee.PasswordHash) ? 
            throw new ArgumentException("Invalid password", nameof(password)) : 
            _tokenGenerator.GenerateToken(employee.Id, employee.Role);
    }
}