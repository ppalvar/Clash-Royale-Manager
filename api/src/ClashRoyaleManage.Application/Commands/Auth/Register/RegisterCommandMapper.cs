using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class RegisterCommandMapper : AbstractMapper<User, RegisterCommand, RegisterCommandResponse>
{
    private readonly IEncryptService encryptService;

    public RegisterCommandMapper(IEncryptService encryptService)
    {
        this.encryptService = encryptService;
    }

    public override User ToEntity(RegisterCommand command)
    {
        return new User{
            Username=command.Username,
            Email=command.Email,
            Password=command.Password
        };
    }
}