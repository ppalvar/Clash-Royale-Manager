using System.ComponentModel.DataAnnotations;

namespace  ClashRoyaleManager.Domain.Entities;

public class Card
{
    [Key]
    public Guid IDCard { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public double ElixirCost { get; set; }

    public string Quality { get; set; }
    
    //Relaciones
    public ICollection<Player> players { get; set; }
}