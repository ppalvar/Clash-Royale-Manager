using System.Collections.Generic;
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public record ListBattleQueryResponse
{ 
    public IEnumerable<BattlePlayerInfo> Battles { get; set; } = null!;
    public int Page { get; set; }
    public int TotalPages { get; set; }
}