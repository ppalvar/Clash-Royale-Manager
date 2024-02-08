using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class Spell
{
    [Key]
    public Guid IdCard { get; set; }

    public int Radio { get; set; }

    public int Duration { get; set; }

    public int DamageToTowers { get; set; }

    public int DamageInArea { get; set; }

     //Relaciones
    [ForeignKey("IdCard")]
    [JsonIgnore]
    public Card card { get; set; }
}