using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class PlayerChallenge
{
    //TODO - Keys [IdPlayer, IdChallenge]
    public Guid IdPlayer { get; set; }
    public Guid IdChallenge { get; set; }

    // Relaciones
    public virtual Player player { get; set; }
    public virtual Challenge challenge { get; set; }
}