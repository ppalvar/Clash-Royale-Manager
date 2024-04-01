namespace ClashRoyaleManager.Application.Queries.PlayerClan.GetAll;

public record GetAllPlayerClanQueryResponse(IQueryable<Domain.Entities.PlayerClan> PlayerClan, int Page, int TotalPages);