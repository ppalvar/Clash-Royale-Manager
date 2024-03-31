using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteSpellCard;

public class DeleteSpellCardCommandHandler : CommandHandler<DeleteSpellCardCommand, DeleteSpellCardCommandResponse>
{
    private readonly ISpellCardRepository _repository;
    private readonly DeleteSpellCardCommandMapper _mapper;

    public DeleteSpellCardCommandHandler(ISpellCardRepository repository)
    {
        _repository = repository;
        _mapper = new DeleteSpellCardCommandMapper();
    }
    
    public override async Task<DeleteSpellCardCommandResponse> ExecuteAsync(DeleteSpellCardCommand command, CancellationToken ct = default)
    {
        SpellCard? spellCard = await _repository.Get1(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(SpellCard)}> and Id <{command.Id}> not exists");

        await _repository.Remove(spellCard.CardId);
        
        return _mapper.ToResponse(spellCard);
    }
}
