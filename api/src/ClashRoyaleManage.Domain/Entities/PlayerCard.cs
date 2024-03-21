using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class PlayerCard
{
    public Guid IdPlayer { get; set; }
    public Guid IdCard { get; set; }

    public Guid IdClan { get; set; }
    public int Level { get; set; }
    public bool IsFavority { get; set; }
    public DateTime Fecha { get; set; }

    //Relaciones
    public virtual Player Player { get; set; }
    public virtual Card Card { get; set; }
    public virtual Clan Clan { get; set; }
}