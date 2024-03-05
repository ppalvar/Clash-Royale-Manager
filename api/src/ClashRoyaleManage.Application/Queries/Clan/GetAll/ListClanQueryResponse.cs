using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public record ListClanQueryResponse
{ 
    public IEnumerable<Clan> Clans { get; set; } = null!;
}