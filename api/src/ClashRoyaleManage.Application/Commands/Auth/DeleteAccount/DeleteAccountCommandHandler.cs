using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class DeleteAccountCommandHandler : ICommandHandler<DeleteAccountCommand, DeleteAccountCommandResponse>
{
    private readonly IUserRepository _repository;
 
    public DeleteAccountCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteAccountCommandResponse> ExecuteAsync(DeleteAccountCommand command, CancellationToken ct = default)
    {

        User user = await _repository.Delete(command.Id);
        
        return new DeleteAccountCommandResponse(
            user.Username,
            user.Email
        );
    }
}