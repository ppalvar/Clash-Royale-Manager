using System.ComponentModel.DataAnnotations;

namespace ClashRoyaleManager.Domain.Entities;

public enum tipo
{
    Invitacion,
    Abierto
}
public class Type
{
    [Key]
    public Guid IdType { get; set; }

    public tipo Name { get; set; }

    //Relaciones
    public ICollection<Clan> clan { get; set; }
}