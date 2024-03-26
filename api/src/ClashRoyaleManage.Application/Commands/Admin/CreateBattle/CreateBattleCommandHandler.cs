using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateBattle;

public class CreateBattleCommandHandler : CommandHandler<CreateBattleCommand, CreateBattleCommandResponse>
{
    private readonly IBattleRepository _repository;
    private readonly CreateBattleCommandMapper _mapper;

    public CreateBattleCommandHandler(IBattleRepository repository)
    {
        _repository = repository;
        _mapper = new CreateBattleCommandMapper();
    }

    public override async Task<CreateBattleCommandResponse> ExecuteAsync(CreateBattleCommand command, CancellationToken ct = default)
    {
        Battle battle = _mapper.ToEntity(command);
        await _repository.Create(battle);
        CreateBattleCommandResponse dev = _mapper.ToResponse(battle);
        return dev;
    }
}