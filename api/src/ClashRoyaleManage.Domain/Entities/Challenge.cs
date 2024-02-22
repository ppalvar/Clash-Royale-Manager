using System.ComponentModel.DataAnnotations;


namespace ClashRoyaleManager.Domain.Entities;

public class Challenge
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public double Cost { get; set; }

    public int NumberOfPrizes { get; set; }

    public int NumberOfAdmissibleDefeats { get; set; }

    public double Duration { get; set; }

    public int MaximumLevel { get; set; }

    public DateTime Date { get; set; }

    // Relaciones
    public virtual ICollection<PlayerChallenge> PlayerChallenges { get; set; }
}