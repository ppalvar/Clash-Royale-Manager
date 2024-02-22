namespace  ClashRoyaleManager.Domain.Entities;

public class Card
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public double ElixirCost { get; set; }

    public string Quality { get; set; }
    
    //Relaciones
    public virtual SpellCard SpellCard { get; set; }
    public virtual StructureCard StructureCard { get; set; }
    public virtual TroopCard TroopCard { get; set; }
    public virtual ICollection<PlayerCard> PlayerCards { get; set; }
}