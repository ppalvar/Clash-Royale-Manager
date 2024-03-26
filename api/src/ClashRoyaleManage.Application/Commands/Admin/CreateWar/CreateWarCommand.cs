using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateWar;

public class CreateWarCommand : ICommand<CreateWarCommandResponse>
{
    public DateTime Date { get; set; }
}