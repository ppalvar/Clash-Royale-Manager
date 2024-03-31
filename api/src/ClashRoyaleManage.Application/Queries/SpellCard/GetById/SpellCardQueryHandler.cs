using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.SpellCards;

public class SpellCardQueryHandler : CommandHandler<SpellCardQuery, SpellCardQueryResponse>
{
    private readonly ISpellCardRepository _repository;
    private readonly SpellCardQueryMapper _mapper;

    public SpellCardQueryHandler(ISpellCardRepository repository)
    {
        _repository = repository;
        _mapper = new SpellCardQueryMapper();
    }

    public override async Task<SpellCardQueryResponse> ExecuteAsync(SpellCardQuery command, CancellationToken ct = default)
    {
        var entitie = await _repository.Get(command.Id);

        return new SpellCardQueryResponse
        {
            Name = entitie.Value.Name,
            Description = entitie.Value.Description,
            Radio = entitie.Value.SpellCard.Radio,
            Duration = entitie.Value.SpellCard.Duration,
            DamageToTowers = entitie.Value.SpellCard.DamageToTowers,
            DamageInArea = entitie.Value.SpellCard.DamageInArea
        };
    }
}