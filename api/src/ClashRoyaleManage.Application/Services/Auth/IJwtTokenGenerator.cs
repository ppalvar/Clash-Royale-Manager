using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Services.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}