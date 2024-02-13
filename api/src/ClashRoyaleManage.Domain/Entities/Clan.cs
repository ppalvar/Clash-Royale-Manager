using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ClashRoyaleManager.Domain.Entities;

public class Clan
{
    public Guid IDClan { get; set; }

    public Guid IdType { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public int NumberOfTrophiesObtainedInWars { get; set; }

    public string Region { get; set; }

    public int NumberOfMembers { get; set; }

    public int TrophiesNeededToEnter { get; set; }

    //Relaciones
    public virtual Type type { get; set; }   
    public virtual ICollection<PlayerCard> playerCard { get; set; }
}