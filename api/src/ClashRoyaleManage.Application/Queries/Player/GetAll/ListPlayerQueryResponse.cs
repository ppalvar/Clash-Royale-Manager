using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Players;

public record ListPlayerQueryResponse
{ 
    public IEnumerable<Player> Players { get; set; } = null!;
    public int Page { get; set; }
    public int TotalPages { get; set; }
}