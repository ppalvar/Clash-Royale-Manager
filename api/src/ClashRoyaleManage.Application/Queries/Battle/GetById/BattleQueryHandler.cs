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
        _mapper = new BattleQueryMapper();
    }

    public override async Task<BattleQueryResponse> ExecuteAsync(BattleQuery command, CancellationToken ct = default)
    {
        var entitie = await _repository.Get(command.Player1Id, command.Player2Id, command.Date);

        return new BattleQueryResponse
        {
            Player1Id = entitie.Value.Battle!.Player1Id,
            Player2Id = entitie.Value.Battle.Player2Id,
            Player1Name = entitie.Value.Player1,
            Player2Name = entitie.Value.Player2,
            Winner = entitie.Value.Battle.Winner,
            NumberOfTrophies = entitie.Value.Battle.NumberOfTrophies,
            Date = entitie.Value.Battle.Date,
            Duration = entitie.Value.Battle.Duration,
        };
    }
}