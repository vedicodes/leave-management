namespace User.Application.Services;

public class AuthService : IAuthService
{
    public Task<string> GetTokenAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
}