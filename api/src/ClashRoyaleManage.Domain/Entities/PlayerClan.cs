using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ClashRoyaleManager.Domain.Entities;

public class PlayerClan
{
    //TODO - Keys [IdPlayer, IdClan]
    public Guid IdPlayer { get; set; }
    public Guid IdClan { get; set; }

    public Guid IdCargo { get; set; }

    //Relaciones
    public virtual Player player { get; set; }
    public virtual Clan clan { get; set; }
    public virtual Cargo cargo { get; set; }
}