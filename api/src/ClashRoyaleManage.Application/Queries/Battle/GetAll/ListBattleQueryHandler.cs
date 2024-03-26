using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public class ListBattleQueryHandler : CommandHandler<ListBattleQuery, ListBattleQueryResponse>
{
    private readonly IBattleRepository _repository;
    private readonly ListBattleQueryMapper _mapper;

    public ListBattleQueryHandler(IBattleRepository repository)
    {
        _repository = repository;
        _mapper = new ListBattleQueryMapper();
    }

    public override async Task<ListBattleQueryResponse> ExecuteAsync(ListBattleQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetAll();

        return new ListBattleQueryResponse
        {
            Battles = data
        };
    }
}