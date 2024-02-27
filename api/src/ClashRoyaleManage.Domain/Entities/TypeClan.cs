using System.ComponentModel.DataAnnotations;

namespace ClashRoyaleManager.Domain.Entities;

public enum TipoEnum
{
    Invitacion,
    Abierto
}

public class TypeClan
{
    public Guid Id { get; set; }
    public TipoEnum Name { get; set; }

    //Relaciones
    public virtual ICollection<Clan> Clans { get; set; }
}