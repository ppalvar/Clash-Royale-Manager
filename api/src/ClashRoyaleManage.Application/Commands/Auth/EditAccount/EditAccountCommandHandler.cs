using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class EditAccountCommandHandler : ICommandHandler<EditAccountCommand, EditAccountCommandResponse>
{
    private readonly IUserRepository _repository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public EditAccountCommandHandler(IUserRepository repository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _repository = repository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<EditAccountCommandResponse> ExecuteAsync(EditAccountCommand command, CancellationToken ct = default)
    {
        User? user = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(User)}> and Id <{command.Id}> not exists");
        
        if (user.Username == command.Username && user.Email == command.Email)
        {
            throw new EntityAlreadyExistException("The current user can't be modified!");
        }

        user.Username = command.Username;
        user.Email = command.Email;
        string token = _jwtTokenGenerator.GenerateToken(user);
        
        await _repository.Update(user);
        
        return new EditAccountCommandResponse(token);
    }
}