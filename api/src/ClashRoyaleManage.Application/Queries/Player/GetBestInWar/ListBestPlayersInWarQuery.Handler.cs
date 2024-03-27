using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Players;

public class ListBestPlayersInWarQueryHandler(IPlayerRepository _playerRepository) : CommandHandler<ListBestPlayersInWarQuery, ListPlayerQueryResponse>
{
    public override async Task<ListPlayerQueryResponse> ExecuteAsync(ListBestPlayersInWarQuery command, CancellationToken ct = default)
    {
        var resp = await _playerRepository.GetBestInWar(command.WarId, command.Page, command.PageSize);

        return new ListPlayerQueryResponse
        {
            Page = command.Page,
            TotalPages = resp.TotalPages,
            Players = resp.Players
        };
    }
}