using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class PlayerCard
{
    [Key]
    public Guid IdPlayerCard { get; set; }

    public Guid IdPlayer { get; set; }

    public Guid IdCard { get; set; }

    public Guid IdClan { get; set; }

    public int Level { get; set; }

    [ForeignKey("IdPlayer")]
    public Player player { get; set; }

    [ForeignKey("IdCard")]
    public Card card { get; set; }

    //Relaciones
    //Relaciones
    [ForeignKey("IdClan")]
    [JsonIgnore]
    public Clan clan { get; set; }
}