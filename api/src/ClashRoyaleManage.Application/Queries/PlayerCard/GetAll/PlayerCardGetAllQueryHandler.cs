using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.PlayerCard.GetAll;

public class PlayerCardGetAllQueryHandler(IPlayerCardRepository _playerCardRepository) : CommandHandler<PlayerCardGetAllQuery, PlayerCardGetAllQueryResponse>
{
    public override async Task<PlayerCardGetAllQueryResponse> ExecuteAsync(PlayerCardGetAllQuery command, CancellationToken ct = default)
    {
        var resp = await _playerCardRepository.GetPagination(command.Page, command.PageSize);
        return new PlayerCardGetAllQueryResponse(resp.playerCards, command.Page, resp.totalPages);
    }
}