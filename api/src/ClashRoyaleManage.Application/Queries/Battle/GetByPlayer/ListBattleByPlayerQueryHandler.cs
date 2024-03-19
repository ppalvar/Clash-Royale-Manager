using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public class ListBattleByPlayerQueryHandler : ICommandHandler<ListBattleByPlayerQuery, ListBattleByPlayerQueryResponse>
{
    private readonly IBattleRepository _repository;
    private readonly ListBattleByPlayerQueryMapper _mapper;

    public ListBattleByPlayerQueryHandler(IBattleRepository repository)
    {
        _repository = repository;
        _mapper = new ListBattleByPlayerQueryMapper();
    }

    public async  Task<ListBattleByPlayerQueryResponse> ExecuteAsync(ListBattleByPlayerQuery command, CancellationToken ct = default)
    {
        var data = await _repository.GetByPlayer(command.Id);

        var response = _mapper.ToResponse(data);

        return response;
    }
}