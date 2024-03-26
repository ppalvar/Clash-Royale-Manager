using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateWar;

public class UpdateWarCommand : ICommand<UpdateWarCommandResponse>
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
}