using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateStructureCard;

public class UpdateStructureCardCommandHandler : CommandHandler<UpdateStructureCardCommand, UpdateStructureCardCommandResponse>
{
    private readonly IStructureCardRepository _repository;
    private readonly UpdateStructureCardCommandMapper _mapper;

    public UpdateStructureCardCommandHandler(IStructureCardRepository repository)
    {
        _repository = repository;
        _mapper = new UpdateStructureCardCommandMapper();
    }
    
    public override async Task<UpdateStructureCardCommandResponse> ExecuteAsync(UpdateStructureCardCommand command, CancellationToken ct = default)
    {
        StructureCard? structureCard = await _repository.Get1(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(StructureCard)}> and Id <{command.Id}> not exists");
        
        if (NotChanges(structureCard, command))
        {
            throw new EntityAlreadyExistException("The current spell card can't be modified!");
        }
        
        structureCard.LifePoints = command.LifePoints;
    
        await _repository.Update(structureCard);
        UpdateStructureCardCommandResponse dev = _mapper.ToResponse(structureCard);
        return dev;
    }

    private bool NotChanges(StructureCard structureCard, UpdateStructureCardCommand command) => structureCard.LifePoints == command.LifePoints;
}
