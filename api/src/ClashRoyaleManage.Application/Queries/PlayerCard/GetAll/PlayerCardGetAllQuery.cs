using FastEndpoints;

namespace ClashRoyaleManager.Application.Queries.PlayerCard.GetAll;

public record PlayerCardGetAllQuery(int Page = 1, int PageSize = 10) : ICommand<PlayerCardGetAllQueryResponse>;