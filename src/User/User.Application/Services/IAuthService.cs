namespace User.Application.Services;

public interface IAuthService
{
    Task<string> GetTokenAsync(string email, string password);
}