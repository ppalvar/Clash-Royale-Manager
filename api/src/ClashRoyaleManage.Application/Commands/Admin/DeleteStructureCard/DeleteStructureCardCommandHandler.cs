using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteStructureCard;

public class DeleteStructureCardCommandHandler : CommandHandler<DeleteStructureCardCommand, DeleteStructureCardCommandResponse>
{
    private readonly IStructureCardRepository _repository;
    private readonly DeleteStructureCardCommandMapper _mapper;

    public DeleteStructureCardCommandHandler(IStructureCardRepository repository)
    {
        _repository = repository;
        _mapper = new DeleteStructureCardCommandMapper();
    }
    
    public override async Task<DeleteStructureCardCommandResponse> ExecuteAsync(DeleteStructureCardCommand command, CancellationToken ct = default)
    {
        StructureCard? structureCard = await _repository.Get1(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(StructureCard)}> and Id <{command.Id}> not exists");

        await _repository.Remove(structureCard.CardId);
        
        return _mapper.ToResponse(structureCard);
    }
}
