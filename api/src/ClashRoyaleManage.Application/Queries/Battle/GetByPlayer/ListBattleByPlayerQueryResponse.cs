using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Battles;

public record ListBattleByPlayerQueryResponse
{ 
    public IEnumerable<Battle> Battles { get; set; } = null!;
}