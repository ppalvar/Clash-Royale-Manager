using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.ClanWar.GetByWar;

public class GetAllClanByWarsQueryHandler(IClanWarRepository _clanWarRepository) : CommandHandler<GetAllClanByWarsQuery, GetAllClanByWarsQueryResponse>
{
    public override async Task<GetAllClanByWarsQueryResponse> ExecuteAsync(GetAllClanByWarsQuery command, CancellationToken ct = default)
    {
        var data = await _clanWarRepository.GetPaginationByWar(command.Id, command.Page, command.PageSize);

        return new GetAllClanByWarsQueryResponse(data.Clans, command.Page, data.totalPages);
    }
}