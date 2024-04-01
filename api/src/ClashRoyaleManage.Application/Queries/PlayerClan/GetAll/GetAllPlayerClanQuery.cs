using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.PlayerClan.GetAll;

public record GetAllPlayerClanQuery(int Page = 1, int PageSize = 10) : ICommand<GetAllPlayerClanQueryResponse>;