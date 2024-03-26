using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public class ListBattleByPlayerQueryHandler : CommandHandler<ListBattleByPlayerQuery, ListBattleByPlayerQueryResponse>
{
    private readonly IBattleRepository _repository;
    private readonly ListBattleByPlayerQueryMapper _mapper;

    public ListBattleByPlayerQueryHandler(IBattleRepository repository)
    {
        _repository = repository;
        _mapper = new ListBattleByPlayerQueryMapper();
    }

    public override async Task<ListBattleByPlayerQueryResponse> ExecuteAsync(ListBattleByPlayerQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetByPlayer(command.Id);

        return new ListBattleByPlayerQueryResponse
        {
            Battles = data
        };
    }
}