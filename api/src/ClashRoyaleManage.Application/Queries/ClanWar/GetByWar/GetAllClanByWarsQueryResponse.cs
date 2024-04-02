namespace ClashRoyaleManager.Application.Queries.ClanWar.GetByWar;

public record GetAllClanByWarsQueryResponse(IQueryable<Domain.Entities.Clan> Clans, int Page, int TotalPages);