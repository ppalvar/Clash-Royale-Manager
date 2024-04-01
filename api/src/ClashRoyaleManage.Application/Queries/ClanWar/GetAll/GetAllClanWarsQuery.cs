using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.ClanWar.GetAll;

public record GetAllClanWarsQuery(int Page = 1, int PageSize = 10) : ICommand<GetAllClanWarsQueryResponse>;