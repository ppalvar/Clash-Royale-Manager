using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class Player
{
    [Key]
    public Guid IdPlayer { get; set; }
    
    public Guid IdCard { get; set; }
    
    public string Nickname { get; set; }

    public int Level { get; set; }

    public int NumberOfTrophies { get; set; }
    
    public int NumberOfWins { get; set; }

    public int MaximunTrophiesAchieved { get; set; }
    public int NumberOfCardsFound { get; set; }
    
    //Relaciones
    [ForeignKey("IdCard")]
    [JsonIgnore]
    public Card card { get; set; }
}