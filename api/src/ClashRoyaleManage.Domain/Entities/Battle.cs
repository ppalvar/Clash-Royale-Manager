using System;
using System.ComponentModel.DataAnnotations;

namespace  ClashRoyaleManager.Domain.Entities;

public class Battle
{
    public Guid Player1Id { get; set; }
    public Guid Player2Id { get; set; } 
    public bool Winner { get; set; }    //NOTE - [false] -> Jugador 1  [true] -> Jugador 2
    public int NumberOfTrophies { get; set; }
    public DateTime Date { get; set; }
    public Datetime Duration { get; set; }

    // Propiedades de navegación
    public virtual Player Player1 { get; set; }
    public virtual Player Player2 { get; set; }
}