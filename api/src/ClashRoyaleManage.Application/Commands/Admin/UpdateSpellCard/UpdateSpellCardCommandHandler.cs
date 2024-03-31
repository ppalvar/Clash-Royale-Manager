using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateSpellCard;

public class UpdateSpellCardCommandHandler : CommandHandler<UpdateSpellCardCommand, UpdateSpellCardCommandResponse>
{
    private readonly ISpellCardRepository _repository;
    private readonly UpdateSpellCardCommandMapper _mapper;

    public UpdateSpellCardCommandHandler(ISpellCardRepository repository)
    {
        _repository = repository;
        _mapper = new UpdateSpellCardCommandMapper();
    }
    
    public override async Task<UpdateSpellCardCommandResponse> ExecuteAsync(UpdateSpellCardCommand command, CancellationToken ct = default)
    {
        SpellCard? spellCard = await _repository.Get1(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(SpellCard)}> and Id <{command.Id}> not exists");
        
        if (NotChanges(spellCard, command))
        {
            throw new EntityAlreadyExistException("The current spell card can't be modified!");
        }
        
        spellCard.Radio = command.Radio;
        spellCard.Duration = command.Duration;
        spellCard.DamageToTowers = command.DamageToTowers;
        spellCard.DamageInArea = command.DamageInArea;

        await _repository.Update(spellCard);
        UpdateSpellCardCommandResponse dev = _mapper.ToResponse(spellCard);
        return dev;
    }

    private bool NotChanges(SpellCard spellCard, UpdateSpellCardCommand command) => spellCard.Radio == command.Radio && spellCard.Duration == command.Duration
            && spellCard.DamageToTowers == command.DamageToTowers && spellCard.DamageInArea == command.DamageInArea;
}
