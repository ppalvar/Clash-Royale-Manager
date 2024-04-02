using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Clans;

public record ListClanQueryResponse
{ 
    public IEnumerable<ClanTypeInfo> Clans { get; set; } = null!;
    public int Page { get; set; }
    public int TotalPages { get; set; }
}