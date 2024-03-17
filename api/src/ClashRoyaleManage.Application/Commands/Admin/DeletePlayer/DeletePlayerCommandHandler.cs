using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeletePlayer;

public class DeletePlayerCommandHandler : CommandHandler<DeletePlayerCommand, DeletePlayerCommandResponse>
{
    private readonly IPlayerRepository _repository;
    private readonly DeletePlayerCommandMapper _mapper;

    public DeletePlayerCommandHandler(IPlayerRepository repository)
    {
        _repository = repository;
        _mapper = new DeletePlayerCommandMapper();
    }
    
    public override async Task<DeletePlayerCommandResponse> ExecuteAsync(DeletePlayerCommand command, CancellationToken ct = default)
    {
        Player? player = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Player)}> and Id <{command.Id}> not exists");

        await _repository.Remove(player.Id);
        
        return _mapper.ToResponse(player);
    }
}
