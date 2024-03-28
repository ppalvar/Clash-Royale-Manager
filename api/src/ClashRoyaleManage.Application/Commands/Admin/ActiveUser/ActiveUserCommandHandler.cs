using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.ActiveUser;

public class ActiveUserCommandHandler : CommandHandler<ActiveUserCommand>
{
    private readonly IUserRepository _repository;

    public ActiveUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public override async Task ExecuteAsync(ActiveUserCommand command, CancellationToken ct = default)
    {
        User? user = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(User)}> and Id <{command.Id}> not exists");
        
        if (user.IsActive == command.Active)
        {
            throw new EntityAlreadyExistException("The current player can't be modified!");
        }

        user.IsActive = command.Active;
        
        await _repository.Update(user);
    }
}
