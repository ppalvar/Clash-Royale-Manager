using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.PlayerClan.GetAll;

public class GetAllPlayerClanQueryHandler(IPlayerClanRepository _playerClanRepository) : CommandHandler<GetAllPlayerClanQuery, GetAllPlayerClanQueryResponse>
{
    public override async Task<GetAllPlayerClanQueryResponse> ExecuteAsync(GetAllPlayerClanQuery command, CancellationToken ct = default)
    {
        var resp = await _playerClanRepository.GetPagination(command.Page, command.PageSize);
        return new GetAllPlayerClanQueryResponse(resp.playerClans, command.Page, resp.totalPages);
    }
}