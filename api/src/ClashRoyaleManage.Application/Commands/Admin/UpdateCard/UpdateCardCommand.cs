using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateCard;

public class UpdateCardCommand : ICommand<UpdateCardCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public double ElixirCost { get; set; }

    public string Quality { get; set; } = null!;
}