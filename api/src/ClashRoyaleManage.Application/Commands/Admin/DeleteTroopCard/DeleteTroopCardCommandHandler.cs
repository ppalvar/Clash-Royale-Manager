using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteTroopCard;

public class DeleteTroopCardCommandHandler : CommandHandler<DeleteTroopCardCommand, DeleteTroopCardCommandResponse>
{
    private readonly ITroopCardRepository _repository;
    private readonly DeleteTroopCardCommandMapper _mapper;

    public DeleteTroopCardCommandHandler(ITroopCardRepository repository)
    {
        _repository = repository;
        _mapper = new DeleteTroopCardCommandMapper();
    }
    
    public override async Task<DeleteTroopCardCommandResponse> ExecuteAsync(DeleteTroopCardCommand command, CancellationToken ct = default)
    {
        TroopCard? troopCard = await _repository.Get1(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(TroopCard)}> and Id <{command.Id}> not exists");

        await _repository.Remove(troopCard.CardId);
        
        return _mapper.ToResponse(troopCard);
    }
}
