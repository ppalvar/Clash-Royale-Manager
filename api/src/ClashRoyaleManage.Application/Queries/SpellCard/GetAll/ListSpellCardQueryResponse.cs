using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.SpellCards;

public record ListSpellCardQueryResponse
{ 
    public IEnumerable<CardInfo> SpellCards { get; set; } = null!;
}