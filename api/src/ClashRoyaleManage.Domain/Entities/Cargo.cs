namespace ClashRoyaleManager.Domain.Entities;

public enum PositionEnum
{
    Lider,
    Colider,
    Veterano,
    Miembro
}

public class Cargo
{
    public Guid IdCargo { get; set; }

    public PositionEnum Name{ get; set; }
}