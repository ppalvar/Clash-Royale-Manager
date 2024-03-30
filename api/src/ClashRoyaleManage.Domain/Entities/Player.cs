using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class Player
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    
    public string Nickname { get; set; }

    public int Level { get; set; }

    public int NumberOfTrophies { get; set; }
    
    public int NumberOfWins { get; set; }

    public int MaximunTrophiesAchieved { get; set; }
    public int NumberOfCardsFound { get; set; }
    
    //Relaciones
    public virtual ICollection<Battle> Battles1 { get; set; }
    public virtual ICollection<Battle> Battles2 { get; set; }
    public virtual ICollection<PlayerCard> PlayerCards { get; set; }
    public virtual ICollection<PlayerChallenge> PlayerChallenges { get; set; }
    public virtual ICollection<PlayerClan> PlayerClans { get; set; }
}