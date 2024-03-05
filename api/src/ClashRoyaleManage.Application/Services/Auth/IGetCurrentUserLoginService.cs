using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Services.Auth;

public interface IGetCurrentUserLoginService
{
    Task<User> Handle(string token);
}