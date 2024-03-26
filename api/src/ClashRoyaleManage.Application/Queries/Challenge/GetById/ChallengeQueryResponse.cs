using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Challenges;

public record ChallengeQueryResponse
{
    public string Name { get; set; }

    public string Description { get; set; }

    public double Cost { get; set; }

    public int NumberOfPrizes { get; set; }

    public int NumberOfAdmissibleDefeats { get; set; }

    public double Duration { get; set; }

    public int MaximumLevel { get; set; }

    public DateTime Date { get; set; }
 
}