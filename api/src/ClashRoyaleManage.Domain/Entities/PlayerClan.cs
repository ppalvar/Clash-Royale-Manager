using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ClashRoyaleManager.Domain.Entities;

public class PlayerClan
{
    [Key]
    public Guid IdPlayerClan { get; set; }

    public Guid IdPlayer { get; set; }

    public Guid IdClan { get; set; }

    public Guid IdCargo { get; set; }

    //Relaciones
    [ForeignKey("IdPlayer")]
    public Player player { get; set; }

    [ForeignKey("IdClan")]
    public Clan clan { get; set; }

    [ForeignKey("IdCargo")]
    public Cargo cargo { get; set; }
}