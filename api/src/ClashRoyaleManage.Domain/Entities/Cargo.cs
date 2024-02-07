using System.ComponentModel.DataAnnotations;

namespace ClashRoyaleManager.Domain.Entities;

public enum position
{
    Lider,
    Colider,
    Veterano,
    Miembro
}
public class Cargo
{
    [Key]
    public Guid IdCargo { get; set; }

    public position Name{ get; set; }
}