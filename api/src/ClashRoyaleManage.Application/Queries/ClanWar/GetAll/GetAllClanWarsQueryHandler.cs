using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.ClanWar.GetAll;

public class GetAllClanWarsQueryHandler(IClanWarRepository _clanWarRepository) : CommandHandler<GetAllClanWarsQuery, GetAllClanWarsQueryResponse>
{
    public override async Task<GetAllClanWarsQueryResponse> ExecuteAsync(GetAllClanWarsQuery command, CancellationToken ct = default)
    {
        var data = await _clanWarRepository.GetPagination(command.Page, command.PageSize);

        return new GetAllClanWarsQueryResponse(data.clanWar, command.Page, data.totalPages);
    }
}