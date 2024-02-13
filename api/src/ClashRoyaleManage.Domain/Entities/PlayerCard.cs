using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class PlayerCard
{
    //NOTE - IDS [IdPlayer, IdCard]
    public Guid IdPlayer { get; set; }
    public Guid IdCard { get; set; }

    public Guid IdClan { get; set; }
    public int Level { get; set; }

    //Relaciones
    public virtual Player player { get; set; }
    public virtual Card card { get; set; }
    public virtual Clan clan { get; set; }
}