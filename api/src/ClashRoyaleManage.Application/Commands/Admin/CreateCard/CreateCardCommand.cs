using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateCard;

public class CreateCardCommand : ICommand<CreateCardCommandResponse>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public double ElixirCost { get; set; }

    public string Quality { get; set; } = null!;
}