using System.ComponentModel.DataAnnotations;

namespace  ClashRoyaleManager.Domain.Entities;

public class War
{
    public Guid IdWar { get; set; }
    public DateTime Date { get; set; }
}