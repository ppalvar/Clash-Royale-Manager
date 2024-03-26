using ClashRoyaleManager.Application.Common;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteChallenge;

public class DeleteChallengeCommandResponse
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