using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.StructureCards;

public record ListStructureCardQueryResponse
{ 
    public IEnumerable<CardInfo1> StructureCards { get; set; } = null!;
    public int Page { get; set; }
    public int TotalPages { get; set; }
}