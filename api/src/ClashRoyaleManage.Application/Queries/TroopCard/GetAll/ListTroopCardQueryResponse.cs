using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.TroopCards;

public record ListTroopCardQueryResponse
{ 
    public IEnumerable<CardInfo2> TroopCards { get; set; } = null!;
    public int Page { get; set; }
    public int TotalPages { get; set; }
}