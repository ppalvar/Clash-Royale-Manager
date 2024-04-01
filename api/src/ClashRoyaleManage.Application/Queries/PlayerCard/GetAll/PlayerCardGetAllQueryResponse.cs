namespace ClashRoyaleManager.Application.Queries.PlayerCard.GetAll;

public record PlayerCardGetAllQueryResponse(IQueryable<Domain.Entities.PlayerCard> PlayerCards, int Page, int TotalPages);