using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class ChangePasswordCommandHandler : CommandHandler<ChangePasswordCommand, ChangePasswordCommandResponse>
{
    private readonly IUserRepository _repository;
    private readonly IEncryptService _encryptService;

    public ChangePasswordCommandHandler(IUserRepository repository, IEncryptService encryptService)
    {
        _repository = repository;
        _encryptService = encryptService;
    }

    public override async Task<ChangePasswordCommandResponse> ExecuteAsync(ChangePasswordCommand command, CancellationToken ct = default)
    {
        User? user = await _repository.Get(command.Id)
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(User)}> and Id <{command.Id}> not exists");

        if (!_encryptService.Decrypt(command.OldPassword, user.Password))
        {
            throw new InvalidCredentialsException("The current password is incorrect!");
        }

        user.Password = _encryptService.Encrypt(command.NewPassword);

        await _repository.Update(user);

        return new ChangePasswordCommandResponse();
    }
}