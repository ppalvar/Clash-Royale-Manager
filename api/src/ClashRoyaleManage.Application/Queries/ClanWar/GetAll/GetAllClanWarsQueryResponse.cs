namespace ClashRoyaleManager.Application.Queries.ClanWar.GetAll;

public record GetAllClanWarsQueryResponse(IQueryable<Domain.Entities.ClanWar> ClanWars, int Page, int TotalPages);