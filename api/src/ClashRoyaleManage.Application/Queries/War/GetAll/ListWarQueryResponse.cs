using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Wars;

public record ListWarQueryResponse
{ 
    public IEnumerable<War> Wars { get; set; } = null!;
}