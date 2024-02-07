using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClashRoyaleManager.Domain.Entities;

public class PlayerChallenge
{
    [Key]
    public Guid IdPlayerChallenge { get; set; }
    
    public Guid IdPlayer { get; set; }

    public Guid IdChallenge { get; set; }

    [ForeignKey("IdPlayer")]
    public Player player { get; set; }

    [ForeignKey("IdChallenge")]
    public Challenge challenge { get; set; }

}