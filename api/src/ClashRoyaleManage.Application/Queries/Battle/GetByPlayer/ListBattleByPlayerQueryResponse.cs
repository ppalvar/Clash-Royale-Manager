using System.Collections.Generic;
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public record ListBattleByPlayerQueryResponse
{ 
    public IEnumerable<BattlePlayerInfo> Battles { get; set; } = null!;
}