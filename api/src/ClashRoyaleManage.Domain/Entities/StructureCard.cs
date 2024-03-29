using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class StructureCard
{
    public Guid CardId { get; set; }
    public int LifePoints { get; set; }

     //Relaciones
    public virtual Card Card { get; set; }
}