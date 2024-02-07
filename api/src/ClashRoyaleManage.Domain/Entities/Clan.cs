using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ClashRoyaleManager.Domain.Entities;

public class Clan
{
    [Key]
    public Guid IDClan { get; set; }

    public Guid IdType { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public int NumberOfTrophiesObtainedInWars { get; set; }

    public string Region { get; set; }

    public int NumberOfMembers { get; set; }

    public int TrophiesNeededToEnter { get; set; }

    //Relaciones
    [ForeignKey("IdType")]
    [JsonIgnore]
    public Type type { get; set; }   

    public ICollection<PlayerCard> playerCard { get; set; }
}