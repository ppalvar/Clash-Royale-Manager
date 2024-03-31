using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateSpellCard;

public class CreateSpellCardCommandHandler : CommandHandler<CreateSpellCardCommand, CreateSpellCardCommandResponse>
{
    private readonly ISpellCardRepository _repository;
    private readonly CreateSpellCardCommandMapper _mapper;

    public CreateSpellCardCommandHandler(ISpellCardRepository repository)
    {
        _repository = repository;
        _mapper = new CreateSpellCardCommandMapper();
    }
    
    public override async Task<CreateSpellCardCommandResponse> ExecuteAsync(CreateSpellCardCommand command, CancellationToken ct = default)
    {
        SpellCard spellCard = _mapper.ToEntity(command);
        await _repository.Create(spellCard);
        CreateSpellCardCommandResponse dev = _mapper.ToResponse(spellCard);
        return dev;
    }
}