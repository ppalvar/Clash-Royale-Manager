namespace  ClashRoyaleManager.Domain.Entities;

public class Card
{
    public Guid IDCard { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public double ElixirCost { get; set; }

    public string Quality { get; set; }
    
    //Relaciones
    public virtual ICollection<Player> players { get; set; }
}