using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Players;

public record ClansCanJoinResponse(IQueryable<Clan> Clans, int Page, int TotalPages);