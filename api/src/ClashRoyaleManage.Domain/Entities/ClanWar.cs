using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace  ClashRoyaleManager.Domain.Entities;

public class ClanWar
{
    [Key]
    public Guid IdClanWar { get; set; }

    public Guid IdWar { get; set; }

    public Guid IdClan { get; set; }

    public int NumberOfPrizes { get; set; }

    [ForeignKey("IdWar")]
    [JsonIgnore]
    public War war { get; set; }

    [ForeignKey("IdClan")]
    [JsonIgnore]
    public Clan clan { get; set; }  
}