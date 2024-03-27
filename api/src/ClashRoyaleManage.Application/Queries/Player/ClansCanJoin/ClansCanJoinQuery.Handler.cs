using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Players;

public class ClansCanJoinQueryHandler(IPlayerRepository _playerRepository) : CommandHandler<ClansCanJoinQuery, ClansCanJoinResponse>
{
    public override async Task<ClansCanJoinResponse> ExecuteAsync(ClansCanJoinQuery command, CancellationToken ct = default)
    {
        var resp = await _playerRepository.GetClansCanJoin(command.PlayerId, command.Page, command.PageSize);

        return new ClansCanJoinResponse(resp.Clans, resp.Page, resp.TotalPages);
    }
}