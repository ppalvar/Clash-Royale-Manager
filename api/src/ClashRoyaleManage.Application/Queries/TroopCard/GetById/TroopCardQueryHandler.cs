using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.TroopCards;

public class TroopCardQueryHandler : CommandHandler<TroopCardQuery, TroopCardQueryResponse>
{
    private readonly ITroopCardRepository _repository;
    private readonly TroopCardQueryMapper _mapper;

    public TroopCardQueryHandler(ITroopCardRepository repository)
    {
        _repository = repository;
        _mapper = new TroopCardQueryMapper();
    }

    public override async Task<TroopCardQueryResponse> ExecuteAsync(TroopCardQuery command, CancellationToken ct = default)
    {
        var entitie = await _repository.Get(command.Id);

        return new TroopCardQueryResponse
        {
            LifePoints = entitie.Value.TroopCard.LifePoints,
            DamageInArea = entitie.Value.TroopCard.DamageInArea,
            NumberOfUnits = entitie.Value.TroopCard.NumberOfUnits,
            Name = entitie.Value.Name,
            Description = entitie.Value.Description
        };
    }
}