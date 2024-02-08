using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class Troop
{
    [Key]
    public Guid IdCard { get; set; }

    public int LifePoints { get; set; }

    public int DamageInArea { get; set; }

    public int NumberOfUnits { get; set; }

    //Relaciones
    [ForeignKey("IdCard")]
    [JsonIgnore]
    public Card card { get; set; }
}