using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Challenges;

public record ListChallengeQueryResponse
{ 
    public IEnumerable<Challenge> Challenges { get; set; } = null!;
    public int Page { get; set; }
    public int TotalPages { get; set; }
}