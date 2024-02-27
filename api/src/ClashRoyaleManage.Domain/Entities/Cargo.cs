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
    public Guid Id { get; set; }
    public PositionEnum Name{ get; set; }

    public virtual ICollection<PlayerClan> PlayerClans { get; set; }
}