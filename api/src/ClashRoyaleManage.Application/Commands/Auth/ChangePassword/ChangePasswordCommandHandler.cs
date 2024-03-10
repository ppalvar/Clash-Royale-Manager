using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand, ChangePasswordCommandResponse>
{
    private readonly IUserRepository _repository;
 
    public ChangePasswordCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ChangePasswordCommandResponse> ExecuteAsync(ChangePasswordCommand command, CancellationToken ct = default)
    {
        User? user = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(User)}> and Id <{command.Id}> not exists");
        
        user.Password = command.NewPassword;
        await _repository.Update(user);
        
        return new ChangePasswordCommandResponse();
    }
}