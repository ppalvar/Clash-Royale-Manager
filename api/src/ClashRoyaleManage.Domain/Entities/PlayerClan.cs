using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ClashRoyaleManager.Domain.Entities;

public class PlayerClan
{
    public Guid IdPlayer { get; set; }
    public Guid IdClan { get; set; }

    public Guid IdCargo { get; set; }

    //Relaciones
    public virtual Player Player { get; set; }
    public virtual Clan Clan { get; set; }
    public virtual Cargo Cargo { get; set; }
}