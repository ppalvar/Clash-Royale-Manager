using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ClashRoyaleManager.Domain.Entities;


public class Clan
{
    public Guid Id { get; set; }

    public Guid IdType { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public int NumberOfTrophiesObtainedInWars { get; set; }

    public RegionsEnum Region { get; set; }

    public int NumberOfMembers { get; set; }

    public int TrophiesNeededToEnter { get; set; }

    //Relaciones
    public virtual TypeClan TypeClan { get; set; }   
    public virtual ICollection<PlayerCard> PlayerCards { get; set; }
    public virtual ICollection<PlayerClan> PlayerClans { get; set; }
    public virtual ICollection<ClanWar> ClanWars { get; set; }
}