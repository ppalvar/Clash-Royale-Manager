using System.ComponentModel.DataAnnotations;

namespace  ClashRoyaleManager.Domain.Entities;

public class War
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }

    public virtual ICollection<ClanWar> ClanWars { get; set; }
}