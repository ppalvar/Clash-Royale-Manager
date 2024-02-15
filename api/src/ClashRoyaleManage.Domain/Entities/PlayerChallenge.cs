using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class PlayerChallenge
{
    public Guid IdPlayer { get; set; }
    public Guid IdChallenge { get; set; }

    // Relaciones
    public virtual Player Player { get; set; }
    public virtual Challenge Challenge { get; set; }
}