using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateTroopCard;

public class UpdateTroopCardCommandHandler : CommandHandler<UpdateTroopCardCommand, UpdateTroopCardCommandResponse>
{
    private readonly ITroopCardRepository _repository;
    private readonly UpdateTroopCardCommandMapper _mapper;

    public UpdateTroopCardCommandHandler(ITroopCardRepository repository)
    {
        _repository = repository;
        _mapper = new UpdateTroopCardCommandMapper();
    }
    
    public override async Task<UpdateTroopCardCommandResponse> ExecuteAsync(UpdateTroopCardCommand command, CancellationToken ct = default)
    {
        TroopCard? troopCard = await _repository.Get1(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(TroopCard)}> and Id <{command.Id}> not exists");
        
        if (NotChanges(troopCard, command))
        {
            throw new EntityAlreadyExistException("The current troop card can't be modified!");
        }
        
        troopCard.LifePoints = command.LifePoints;
        troopCard.DamageInArea = command.DamageInArea;
        troopCard.NumberOfUnits = command.NumberOfUnits;

        await _repository.Update(troopCard);
        UpdateTroopCardCommandResponse dev = _mapper.ToResponse(troopCard);
        return dev;
    }

    private bool NotChanges(TroopCard troopCard, UpdateTroopCardCommand command) => troopCard.LifePoints == command.LifePoints && troopCard.DamageInArea == command.DamageInArea && troopCard.NumberOfUnits == command.NumberOfUnits;
}
