using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public class BattleQueryHandler : CommandHandler<BattleQuery, BattleQueryResponse>
{
    private readonly IBattleRepository _repository;
    private readonly BattleQueryMapper _mapper;

    public BattleQueryHandler(IBattleRepository repository)
    {
        _repository = repository;
    }

    public override async Task<BattleQueryResponse> ExecuteAsync(BattleQuery command, CancellationToken ct = default)
    {
        var entitie = await _repository.Get(command.Player1Id, command.Date);

        return new BattleQueryResponse
        {
            Player1Id = entitie.Battle!.Player1Id,
            Player2Id = entitie.Battle.Player2Id,
            Player1Name = entitie.Player1,
            Player2Name = entitie.Player2,
            Winner = entitie.Battle.Winner,
            NumberOfTrophies = entitie.Battle.NumberOfTrophies,
            Date = entitie.Battle.Date,
            Duration = entitie.Battle.Duration,
        };
    }
}