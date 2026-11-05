using User.Domain.Enums;

namespace User.Application.Contracts;

public interface ITokenGenerator
{
    string GenerateToken(Guid userId, UserRole role);
}